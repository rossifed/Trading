using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Abstractions.Queries;
namespace Quantaventis.Trading.Shared.Infrastructure.Queries
{
    internal class QueryDispatcher :IQueryDispatcher
    {
        private IServiceProvider ServiceProvider { get; }

        public QueryDispatcher(IServiceProvider serviceProvider)
            => ServiceProvider = serviceProvider;

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            using var scope = ServiceProvider.CreateScope();
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = scope.ServiceProvider.GetRequiredService(handlerType);
            var method = handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync));
            if (method is null)
            {
                throw new InvalidOperationException($"Query handler for '{typeof(TResult).Name}' is invalid.");
            }

            // ReSharper disable once PossibleNullReferenceException
            return await (Task<TResult>)method.Invoke(handler, new object[] { query, cancellationToken });
        }
    }
}
