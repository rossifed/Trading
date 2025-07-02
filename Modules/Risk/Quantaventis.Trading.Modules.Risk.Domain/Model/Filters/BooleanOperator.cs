namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal class BooleanOperator
    {

        private const string OR = "OR";
        private const string AND = "AND";

        private string Mnemonic { get; }

        private Func<bool, bool, bool> OperatorFunction;
        private BooleanOperator(string mnemonic, Func<bool, bool, bool> operatorFunction)
        {
            this.Mnemonic = mnemonic;

            this.OperatorFunction = operatorFunction;
        }

        internal bool Apply(bool value1, bool value2)
            => OperatorFunction(value1, value2);


        internal static BooleanOperator And()
            => new BooleanOperator(AND, (x1, x2) => x1 && x2);

        internal static BooleanOperator Or()
            => new BooleanOperator(OR, (x1, x2) => x1 || x2);



        public override string ToString()
         => Mnemonic;

        internal static BooleanOperator Create(string mnemonic)
        {
            switch (mnemonic.Trim().ToUpper())
            {
                case AND:
                    return And();
                case OR:
                    return Or();
                default: throw new ArgumentException($"The Boolean Operator {mnemonic} is not supported");
            }
        }

        public override bool Equals(object? obj)
         => obj is BooleanOperator @operator &&
                   Mnemonic == @operator.Mnemonic;


        public override int GetHashCode()
         => HashCode.Combine(Mnemonic);

    }
}
