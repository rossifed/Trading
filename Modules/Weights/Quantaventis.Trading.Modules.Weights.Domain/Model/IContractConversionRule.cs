using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Model
{
    internal interface IContractConversionRule
    {

        bool ApplyTo(ModelWeight modelWeight);
        ConvertedWeight Apply(ModelWeight modelWeight);
    }
}
