using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Risk.Domain.Model;
using Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints;
using System.Reflection;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Mappers
{
    internal static class Extentions
    {
      internal static  Constraint Map(this Entities.Constraint entity, IConstraintFactory constraintFactory)
            => constraintFactory.Create(entity.ConstraintId,entity.ConstraintType.Mnemonic, entity.RelationalOperator.Map(), (double)entity.LimitValue);
        
        internal static IEnumerable<Domain.Model.Constraints.Constraint> Map(this IEnumerable<Entities.Constraint> entities, IConstraintFactory constraintFactory)
         => entities.Select(x => x.Map(constraintFactory));
        

        internal static RelationalOperator Map(this Entities.RelationalOperator entity)
        {
            return  RelationalOperator.Create(entity.Mnemonic);
        }

        internal static Entities.ConstraintBreach Map(this ConstraintBreach domain)
        {
            return new Entities.ConstraintBreach()
            {
                CheckedValue = domain.CheckedValue,
                LimitValue = domain.LimitValue,
                ConstraintId = domain.Constraint.Id,
                Message = domain.Message,
            };
        }
        internal static Entities.TargetAllocationCheck Map(this TargetAllocationCheck domain)
        {
            var entity = new Entities.TargetAllocationCheck()
            {
                TargetAllocationId = domain.TargetAllocation.Id,
                CheckedOn = DateTime.Now,
                IsBreach = domain.IsBreach,
            };

            domain.Breaches.ToList().ForEach(x => entity.ConstraintBreaches.Add(x.Map()));
            return entity;
        }
    }
}
