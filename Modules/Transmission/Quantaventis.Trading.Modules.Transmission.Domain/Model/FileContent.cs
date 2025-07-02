using CsvHelper.Configuration.Attributes;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class FileContent
    {

        internal string ContentStr { get; }
        internal string Header { get; }
        internal string[] Rows { get; }
        internal int RowsCount => Rows.Length;
        internal bool HasHeader { get; }


    internal FileContent(string header, string[] rows) 
        {
            Header = header;
            Rows  = rows;
            HasHeader =  !header.IsNullOrEmpty();
        

            ContentStr = BuildContentStr();
        }
        
        private string BuildContentStr()
        {
            StringBuilder sb = new StringBuilder();
            if (HasHeader)
                sb.AppendLine(Header);
            foreach (var row in Rows)
            {
                sb.AppendLine(row);
            }

            return sb.ToString();
        }

      internal FileContent(string[] rows) : this("", rows)
        {

        }
        internal FileContent() : this("", new string[]{ })
        {

        }
      
        internal bool IsEmpty =>RowsCount == 0;



        public override string ToString() {

            return ContentStr;
        }

        public override bool Equals(object? obj)
        {
            return obj is FileContent content &&
                   ContentStr == content.ContentStr;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ContentStr);
        }
    }
}
