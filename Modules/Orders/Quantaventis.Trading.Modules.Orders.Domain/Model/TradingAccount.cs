using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class TradingAccount
    {
       internal int Id { get; }
        internal string Code { get; }



        internal TradingAccount(int id, string code)
        {
            Id = id;
            Code = code;

        }

        public override string? ToString()
        {
            return Code;
        }
    }
}
