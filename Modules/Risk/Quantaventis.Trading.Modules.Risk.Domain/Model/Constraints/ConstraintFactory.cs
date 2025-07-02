using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal interface IConstraintFactory
    {
        internal Constraint Create(int id, string constraintType, RelationalOperator relationalOperator, double limitValue);
    }
    internal class ConstraintFactory : IConstraintFactory
    {

        public Constraint Create(int id, string constraintType, RelationalOperator relationalOperator, double limitValue)
        {
            switch (constraintType)
            {
                case "SGE": return new SingleGrossExposureConstraint(id,relationalOperator, limitValue);
                case "SNE": return new SingleNetExposureConstraint(id,  relationalOperator, limitValue);
                case "GGE": return new GlobalGrossExposureConstraint(id, relationalOperator, limitValue);
                case "GNE": return new GlobalNetExposureConstraint(id, relationalOperator, limitValue);
                default: throw new NotSupportedException($"The constraint type {constraintType} is not recognized");
            }

        }
    }
}
