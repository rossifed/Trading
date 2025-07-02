using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Model
{
    internal class ModelWeighting
    {

        internal int Id { get; }
   

        internal PortfolioId PortfolioId { get; }

        internal DateTime GeneratedOn { get; }
        internal ModelWeighting(int id,
            PortfolioId portfolioId,
            DateTime generatedOn,
            IEnumerable<ModelWeight> modelWeights)
        {

            this.Id = id;
            this.PortfolioId = portfolioId;
            this.GeneratedOn = generatedOn;
            this.ModelWeights = modelWeights;
        }

        internal IEnumerable<ModelWeight> ModelWeights { get; }

    }
}



