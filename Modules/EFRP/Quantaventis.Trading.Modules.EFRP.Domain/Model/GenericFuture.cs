using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class GenericFuture : Instrument
    {

        internal double ContractSize { get; }
        internal decimal PointValue { get; }


        public GenericFuture(int id,
            string symbol,
            double contractSize,
            decimal pointValue
        ) : base(id, symbol)
        {

            ContractSize = contractSize;
            PointValue = pointValue;

        }
    }
}
