using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Infrastructure.Database
{
    public interface IUnitOfWork
    {
        Task<T> ExecuteAsync<T>(Func<Task<T>> action);
        Task ExecuteAsync(Func<Task> action);
    }
}
