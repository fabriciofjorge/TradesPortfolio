using System;
using System.Collections.Generic;
using System.Globalization;
using TradesPortfolio.Entities;
using TradesPortfolio.UseCases;

namespace TradesPortfolio.Controllers
{
    public class TradeController
    {
        public IList<string> EvaluateCategory(string referenceDate, int tradesToEvaluate, IList<string> tradesList)
        {
            DateTime.TryParse(referenceDate, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out DateTime _referenceDate);

            if (!IsValidReferenceDate(_referenceDate) || !IsValidNumberOfTrades(tradesToEvaluate, tradesList))
            {
                return null;
            }

            var results = new List<string>();
            var tradeCategory = new TradeCategory();
            foreach (string item in tradesList)
            {
                var trade = Trade.CreateTradeFromString(item);

                results.Add(tradeCategory.Evaluate(trade, _referenceDate));
            }

            return results;
        }

        private bool IsValidReferenceDate(DateTime date)
        {
            if (date == null || date == DateTime.MinValue || date > DateTime.Now)
                return false;

            return true;
        }

        private bool IsValidNumberOfTrades(int tradesQuantity, IList<string> tradesList)
        {
            return tradesQuantity == tradesList?.Count && tradesQuantity > 0;
        }
    }
}
