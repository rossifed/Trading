namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal class RelationalOperator
    {

        private const string GT = "GT";
        private const string GEQ = "GEQ";
        private const string LT = "LT";
        private const string LEQ = "LEQ";
        private const string EQ = "EQ";
        private const string NEQ = "NEQ";
        private string Symbol { get; }

        private string Name { get; }
        private string Mnemonic { get; }

        private Func<double, double, bool> OperatorFunction;
        private RelationalOperator(string mnemonic, string name, string symbol, Func<double, double, bool> operatorFunction)
        {
            this.Mnemonic = mnemonic;
            this.Name = name;
            this.Symbol = symbol;
            this.OperatorFunction = operatorFunction;
        }

        internal bool Apply(double value1, double value2)
            => OperatorFunction(value1, value2);


        internal static RelationalOperator GreaterThan()
            => new RelationalOperator(GT, "Greather Than", ">", (x1, x2) => x1 > x2);

        internal static RelationalOperator GreaterOrEqualThan()
            => new RelationalOperator(GEQ, "Greather Or Equal Than", ">=", (x1, x2) => x1 >= x2);

        internal static RelationalOperator LessThan()
            => new RelationalOperator(LT, "Less Than", "<", (x1, x2) => x1 < x2);

        internal static RelationalOperator LessOrEqualThan()
            => new RelationalOperator(LEQ, "Less Or Equal Than", "<=", (x1, x2) => x1 <= x2);

        internal static RelationalOperator EqualThan()
            => new RelationalOperator(EQ, "Equal Than", "=", (x1, x2) => x1 == x2);

        internal static RelationalOperator NotEqualThan()
            => new RelationalOperator(NEQ, "Not Equal Than", "<>", (x1, x2) => x1 != x2);

        internal RelationalOperator Inverse()
        {
            switch (Mnemonic.Trim().ToUpper())
            {
                case GT:
                    return LessOrEqualThan();
                case GEQ:
                    return LessThan();
                case LT:
                    return GreaterOrEqualThan();
                case LEQ:
                    return GreaterThan();
                case EQ:
                    return NotEqualThan();
                case NEQ:
                    return EqualThan();
                default: throw new ArgumentException($"The Relational Operator {Mnemonic} is not supported");
            }
        }

        public override string ToString()
         => Name;

        internal static RelationalOperator Create(string mnemonic)
        {
            switch (mnemonic.Trim().ToUpper())
            {
                case GT:
                    return GreaterThan();
                case GEQ:
                    return GreaterOrEqualThan();
                case LT:
                    return LessThan();
                case LEQ:
                    return LessOrEqualThan();
                case EQ:
                    return EqualThan();
                case NEQ:
                    return NotEqualThan();
                default: throw new ArgumentException($"The Relational Operator {mnemonic} is not supported");
            }
        }

        public override bool Equals(object? obj)
         => obj is RelationalOperator @operator &&
                   Mnemonic == @operator.Mnemonic;


        public override int GetHashCode()
         => HashCode.Combine(Mnemonic);

    }
}
