using System.Collections.Generic;
using TradesPortfolio.Controllers;
using Xunit;

namespace TradesPortfolio.Test.Controller
{
    public class TradeControllerTest
    {
        private readonly TradeController tradeController = new TradeController();

        [Fact]
        public void MustShowAValidResultWithAValidInput()
        {
            string refDate = "12/11/2020";
            int numTrades = 4;
            var trades = new List<string>()
            {
                "2000000 Private 12/29/2025",
                "400000 Public 07/01/2020",
                "5000000 Public 01/02/2024",
                "3000000 Public 10/26/2023"
            };

            var results = tradeController.EvaluateCategory(refDate, numTrades, trades);

            var expectedResults = new List<string>()
            {
                "HIGHRISK",
                "EXPIRED",
                "MEDIUMRISK",
                "MEDIUMRISK"
            };

            Assert.Equal(expectedResults, results);
        }

        [Fact]
        public void ShoudlNotEvaluateWithoutReferenceDate()
        {
            string refDate = "";
            int numTrades = 1;
            var trades = new List<string>()
            {
                "3000000 Public 10/26/2023"
            };

            var result = tradeController.EvaluateCategory(refDate, numTrades, trades);

            Assert.True(result == null);
        }

        [Fact]
        public void ShoudlNotEvaluateWithoutTrades()
        {
            string refDate = "12/11/2020";
            int numTrades = 0;
            var trades = new List<string>();

            var result = tradeController.EvaluateCategory(refDate, numTrades, trades);

            Assert.True(result == null);
        }

        [Fact]
        public void ShoudlNotEvaluateWithInvalidTradeParameters()
        {
            string refDate = "12/11/2020";
            int numTrades = 1;
            var trades = new List<string>()
            {
                "2000000 Private 12/29/2025",
                "3000000 Public 10/26/2023"
            };

            var result = tradeController.EvaluateCategory(refDate, numTrades, trades);

            Assert.True(result == null);
        }
    }
}
