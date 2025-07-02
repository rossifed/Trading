using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public class HandlingInstruction
    {
        private string Code { get; }
        public HandlingInstruction(string code)
        {
            this.Code = code;
        }


        public static implicit operator HandlingInstruction(string code) => new(code);

        public static implicit operator string(HandlingInstruction handlingInstruction) => handlingInstruction.Code;



        public override string? ToString()
         => Code;

        public override bool Equals(object? obj)
        {
            return obj is HandlingInstruction type &&
                   Code == type.Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }
    }
}
