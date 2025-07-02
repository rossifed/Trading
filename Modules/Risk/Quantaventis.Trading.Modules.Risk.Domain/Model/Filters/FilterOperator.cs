namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal class FilterOperator<T> where T : class
    {

        private const string EQ = "EQ";
        private const string DIF = "DIF";

        private string Mnemonic { get; }

        private Func<T, T, bool> OperatorFunction;
        private FilterOperator(string mnemonic, Func<T, T, bool> operatorFunction)
        {
            this.Mnemonic = mnemonic;

            this.OperatorFunction = operatorFunction;
        }

        internal bool Apply(T party1, T party2)
            => OperatorFunction(party1, party2);


        internal static FilterOperator<T> Equal()
            => new FilterOperator<T>(EQ, (x1, x2) => x1.Equals(x2));

        internal static FilterOperator<T> Different()
            => new FilterOperator<T>(DIF, (x1, x2) => !x1.Equals(x2));

        public override string ToString()
         => Mnemonic;

        internal static FilterOperator<T> Create(string mnemonic)
        {
            switch (mnemonic.Trim().ToUpper())
            {
                case EQ:
                    return Equal();
                case DIF:
                    return Different();

                default: throw new ArgumentException($"The Boolean Operator {mnemonic} is not supported");
            }
        }

        public override bool Equals(object? obj)
        => obj is FilterOperator<T> @operator &&
                   Mnemonic == @operator.Mnemonic;


        public override int GetHashCode()
         => HashCode.Combine(Mnemonic);

    }
}
