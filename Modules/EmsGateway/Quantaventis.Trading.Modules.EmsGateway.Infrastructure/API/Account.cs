using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public class Account
    {
        private string Code { get; }
        public Account(string code)
        {
            this.Code = code;
        }


        public static implicit operator Account(string code) => new(code);

        public static implicit operator string(Account account) => account.Code;



        public override string? ToString()
         => Code;

        public override bool Equals(object? obj)
        {
            return obj is Account type &&
                   Code == type.Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }
    }
}
