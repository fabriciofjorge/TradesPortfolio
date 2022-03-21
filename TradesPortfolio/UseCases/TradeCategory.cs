using System;
using System.Collections.Generic;
using TradesPortfolio.Entities;
using TradesPortfolio.UseCases.CategoryRules;

namespace TradesPortfolio.UseCases
{
    public class TradeCategory
    {
        private readonly IList<CategoryRule> categories;

        public TradeCategory()
        {
            categories = new List<CategoryRule>
            {
                new ExpiredTrade(),
                new HighRiskTrade(),
                new MediumRiskTrade()
            };
        }

        public string Evaluate(Trade trade, DateTime referenceDate)
        {
            foreach (var category in categories)
            {
                var result = category.GetRule(trade, referenceDate);

                if (result != string.Empty)
                {
                    return result;                    
                }
            }

            return "";
        }
    }
}
