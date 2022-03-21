using System;
using TradesPortfolio.Entities;

namespace TradesPortfolio.UseCases.CategoryRules
{
    public class HighRiskTrade : CategoryRule
    {
        public override string GetRule(Trade trade, DateTime referenceDate)
        {
            return (trade.Value > 1000000 && trade.ClientSector.ToLower() == "private") ? "HIGHRISK" : string.Empty;
        }
    }
}
