BEGIN TRY
    -- Define the test server name and database name
    DECLARE @TestServerName NVARCHAR(128) = 'test-trading-sqlsrv';
    DECLARE @TestDatabaseName NVARCHAR(128) = 'Trading';

    -- Get the current server name and database name
    DECLARE @CurrentServerName NVARCHAR(128);
    DECLARE @CurrentDatabaseName NVARCHAR(128);
    SELECT @CurrentServerName = @@SERVERNAME;
    SELECT @CurrentDatabaseName = DB_NAME();

    -- Check if the script is running on the test server and database
    IF @CurrentServerName <> @TestServerName OR @CurrentDatabaseName <> @TestDatabaseName
    BEGIN
        RAISERROR('This script is intended to run only on the test server and database. Execution aborted.', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;

    -- Step 1: Drop all foreign key constraints
    DECLARE @dropConstraints NVARCHAR(MAX) = N'';
    SELECT @dropConstraints += 'ALTER TABLE ' + QUOTENAME(s.name) + '.' + QUOTENAME(t.name) + ' DROP CONSTRAINT ' + QUOTENAME(f.name) + ';' + CHAR(13)
    FROM sys.foreign_keys f
    JOIN sys.tables t ON f.parent_object_id = t.object_id
    JOIN sys.schemas s ON t.schema_id = s.schema_id;
    EXEC sp_executesql @dropConstraints;

    -- Step 2: Disable system versioning on all temporal tables and drop them along with their history tables
    DECLARE @dropTemporalTables NVARCHAR(MAX) = N'';
    SELECT @dropTemporalTables += 
        'ALTER TABLE ' + QUOTENAME(s.name) + '.' + QUOTENAME(t.name) + ' SET (SYSTEM_VERSIONING = OFF);' + CHAR(13) +
        'DROP TABLE ' + QUOTENAME(s.name) + '.' + QUOTENAME(t.name) + ';' + CHAR(13) +
        'DROP TABLE ' + QUOTENAME(s.name) + '.' + QUOTENAME(ht.name) + ';' + CHAR(13)
    FROM sys.tables t
    JOIN sys.schemas s ON t.schema_id = s.schema_id
    JOIN sys.tables ht ON t.history_table_id = ht.object_id
    WHERE t.temporal_type = 2; -- Temporal table
    EXEC sp_executesql @dropTemporalTables;

    -- Step 3: Drop all remaining tables
    DECLARE @dropTables NVARCHAR(MAX) = N'';
    SELECT @dropTables += 'DROP TABLE ' + QUOTENAME(s.name) + '.' + QUOTENAME(t.name) + ';' + CHAR(13)
    FROM sys.tables t
    JOIN sys.schemas s ON t.schema_id = s.schema_id
    WHERE t.temporal_type <> 2; -- Non-temporal table
    EXEC sp_executesql @dropTables;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;

    DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();
    
    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH;
