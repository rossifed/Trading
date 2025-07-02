namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Files
{
    internal class ModelWeightingFile
    {

        public string FileName { get; }

        public byte PortfolioId { get;}

        public DateTime CreatedOn { get;  }

        public DateTime ModifiedOn { get; }

        public DateTime IntegratedOn { get;  }

        public IEnumerable<(string Symbol, double Weight)> ModelWeights { get;  }

        public IEnumerable<string> Symbols => ModelWeights.Select(x => x.Symbol).Distinct().ToList();

        internal ModelWeightingFile(string fileName,
            byte portfolioId,
            DateTime CreatedOn,
            DateTime modifiedOn,
            IEnumerable<(string symbol, double weight)> modelWeights)
        {
            this.FileName = fileName;
            this.PortfolioId = portfolioId;
            this.CreatedOn = CreatedOn;
            this.ModifiedOn = modifiedOn;
            this.ModelWeights = modelWeights;

        }
    

    }
}
