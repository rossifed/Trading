using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class FileNameTemplate
    {
        private string Value { get; }
  

        internal FileNameTemplate(string fileName)
        { 
            this.Value = fileName;
       
        }
        internal FileName WithoutTimeStamp()
        {

            return new FileName(Value);


        }
        internal FileName FormatWithTimeStamp(DateTime timestamp, string format) {

            return new FileName(string.Format(Value, timestamp.ToString(format)));


        }

        public override bool Equals(object? obj)
        {
            return obj is FileNameTemplate template &&
                   Value == template.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string ToString() { return  Value; }    
    }
}
