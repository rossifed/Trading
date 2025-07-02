using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Infrastructure.Database
{
    public class UnitOfWorkRegistry
    {
        private Dictionary<string, Type> Type { get; }

        public UnitOfWorkRegistry() {
            Type = new();
        }

        public void Register<T>() where T : IUnitOfWork => Type[GetKey<T>()] = typeof(T);

        public Type? Resolve<T>() => Type.TryGetValue(GetKey<T>(), out var type) ? type : null;

        private static string GetKey<T>() => $"{typeof(T).GetModuleName()}";
    }
}
