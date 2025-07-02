using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class FutureContract :Instrument
    {
        internal GenericFuture GenericFuture { get; }

        internal double ContractSize => GenericFuture.ContractSize;
        internal decimal PointValue => GenericFuture.PointValue;
        internal DateOnly LastTradeDate { get; }

        public FutureContract(int id, 
            string symbol,
            GenericFuture genericFuture,
            DateOnly lastTradeDate): base(id,symbol)
        {
            GenericFuture = genericFuture;
            LastTradeDate = lastTradeDate;
        }
    }
}
