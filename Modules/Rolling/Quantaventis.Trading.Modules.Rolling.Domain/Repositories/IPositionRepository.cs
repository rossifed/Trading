using Quantaventis.Trading.Modules.Rolling.Domain.Model;
namespace Quantaventis.Trading.Modules.Rolling.Domain.Repositories
{
    internal interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllAsync();
        Task<IEnumerable<Position>> GetByPortfolioIdAsync(byte portfolioId);
    }
}
