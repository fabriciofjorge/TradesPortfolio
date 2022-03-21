using System;
using TradesPortfolio.Entities;

namespace TradesPortfolio.UseCases.CategoryRules
{
    public class MediumRiskTrade : CategoryRule
    {
        public override string GetRule(Trade trade, DateTime referenceDate)
        {
            return (trade.Value > 1000000 && trade.ClientSector.ToLower() == "public") ? "MEDIUMRISK" : string.Empty;
        }
    }
}
