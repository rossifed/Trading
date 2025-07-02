
namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class TransmissionFile
    {
        internal FileName FileName { get; }

        internal Folder Directory { get; }
        internal string FullPath { get; }

        internal FileContent Content { get; }

        internal int RowsCount => Content.RowsCount;
   
        internal TransmissionFile(FileName fileName, Folder directory) : this(fileName, directory, new FileContent()) { }
        internal TransmissionFile(FileName fileName, Folder directory, FileContent fileContent)
        {
            this.FileName = fileName;
            this.Directory = directory;
            this.FullPath = Path.Combine(directory.Path, fileName.Value);
            this.Content = fileContent;
        }

        internal TransmissionFile ChangeFolder(Folder newFolder)
            => new TransmissionFile(FileName, newFolder, Content);
        
        internal TransmissionFile AddContent(FileContent content)

            => new TransmissionFile(FileName, Directory, content);

        internal TransmissionFile AddExtension(string extension)
                    => new TransmissionFile(FileName.AddExtension(extension), Directory, Content);

        internal FileName GetFileNameWithoutExtension()
            => FileName.WithoutExtension();

        internal string GetExtension()
                 => FileName.GetExtension();


        internal TransmissionFile AddTimeStamp(DateTime timeStamp, string format)
         => new TransmissionFile(FileName.AddTimeStamp(timeStamp, format), Directory, Content);

        public override bool Equals(object? obj)
        {
            return obj is TransmissionFile file &&
                   FullPath == file.FullPath &&
                   EqualityComparer<FileContent>.Default.Equals(Content, file.Content);
        }

        public override int GetHashCode()
         => HashCode.Combine(FullPath, Content);
        

        public override string? ToString()
        => FullPath;
        
    }
}
