using System;
using TradesPortfolio.Entities;

namespace TradesPortfolio.UseCases.CategoryRules
{
    public class ExpiredTrade : CategoryRule
    {
        public override string GetRule(Trade trade, DateTime referenceDate)
        {
            return (referenceDate.AddDays(30) > trade.NextPaymentDate) ? "EXPIRED" : string.Empty;
        }
    }
}
