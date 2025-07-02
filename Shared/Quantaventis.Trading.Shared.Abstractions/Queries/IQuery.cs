using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Abstractions.Queries
{
    //Marker
    public interface IQuery
    {
    }

    public interface IQuery<T> : IQuery { 
    
    }
}
