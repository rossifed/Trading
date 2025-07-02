This project is only aiming to generate the DbContext and the related entities using the  Entity Framework Scaffolding tool.
As the scaffolding injecting the DB name is not possible directly from a class library project.
For this intent here are the prerequisite:
	1.This project must referenc Microsoft.EntityFramework.SqlServer and Microsoft.EntityFramework.Tools packages
	2.Add the named connection string in the appsettings.json of this project and the final Asp.net web api project
	3.Ensure the user who generate the DBContext has the sufficient db permission

The generated folders can then be copied to the  folder of the project (the one specified by the -namespace param)

Example of scaffold script:
Scaffold-DbContext Name=QntTradingDatabase Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Schema wght -Force -namespace Qnt.Trading.Modules.Tools.Infrastructure.Entities


From version 7.0.0 of EntityFrameworkCore. you may bump into the following error:
A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - The certificate chain was issued by an authority that is not trusted.

To bypass this error, you can add  TrustServerCertificate=True; in specified the datasource

P.S: Solution must successfully compile to allow db scaffolding
