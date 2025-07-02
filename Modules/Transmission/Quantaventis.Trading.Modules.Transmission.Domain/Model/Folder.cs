using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class Folder
    {
        internal string Path { get; }

        internal Folder(string path)
        {
            Path = path;
        }

       internal Folder Combine(Folder folder) {

            return new Folder(System.IO.Path.Combine(Path, folder.Path));
        }

        internal TransmissionFile CreateFile(FileName fileName)
        {

            return new TransmissionFile(fileName, this);
        }

        public override bool Equals(object? obj)
        {
            return obj is Folder folder &&
                   Path == folder.Path;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Path);
        }

        public override string ToString() { return Path; }
    }
}
