using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal struct Broker
    {
        int Id { get; }

        public Broker(int id)
        {
            Id = id;
        }
    }
}
