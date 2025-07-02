using Quantaventis.Trading.Modules.Rebalancing.Domain.Services;
namespace Quantaventis.Trading.Modules.Rebalancing.Tests.Domain.Services
{
    public class TradeDateResolverTest
    {
        [Theory]
        [InlineData("23:00", "2023-10-16 04:00:00", "2023-10-16")]
        [InlineData("23:00", "2023-10-16 00:00:00", "2023-10-16")]
        [InlineData("23:00", "2023-10-16 23:01:00", "2023-10-17")]
        public void Test1(string switchTimeStr, string nowStr, string expectedDateStr)
        {
            TimeOnly switchTime = TimeOnly.Parse(switchTimeStr);
            DateTime rebalTime = DateTime.Parse(nowStr);
            DateOnly expectedDate = DateOnly.Parse(expectedDateStr);
            ITradeDateResolver tradeDateResolver = new TradeDateResolver();
            DateOnly result = tradeDateResolver.NextTradeDate(switchTime, rebalTime);
            Assert.Equal(result, expectedDate);
        }
    }
}
