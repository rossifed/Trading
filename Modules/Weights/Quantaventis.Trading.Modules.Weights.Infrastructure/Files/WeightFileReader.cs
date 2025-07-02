namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Files
{
    internal interface IWeightFileReader {
        Task<ModelWeightingFile> ReadAsync(byte portfolioId, string filePath);
    }
    internal class WeightFileReader : IWeightFileReader
    {
  
        private char Separator { get; }

        public WeightFileReader(char separator) {
            this.Separator = separator;
        }
        public async Task<ModelWeightingFile> ReadAsync(byte portfolioId, string filePath)
        {
            string[] lines = await File.ReadAllLinesAsync(filePath);
            DateTime lastWriteTime = File.GetLastWriteTime(filePath);

            IEnumerable<(string symbol, double weight)> weights = ReadWeights(lines, Separator);

            return new ModelWeightingFile(Path.GetFileName(filePath),
                portfolioId,
                File.GetCreationTime(filePath),
                File.GetLastWriteTime(filePath),
                weights);

        }
        private (string symbol, double weight) ReadLine(string[] lineValues)
        {
            string symbol = Convert.ToString(lineValues[0]);
            double weight = double.Parse(lineValues[1], System.Globalization.CultureInfo.InvariantCulture);
            return (symbol,weight);
        }
        private ICollection<(string symbol, double weight)> ReadWeights(string[] lines, char separator)
          => lines.Select(line => ReadLine(line.Split(separator))).ToList();
    }
}
