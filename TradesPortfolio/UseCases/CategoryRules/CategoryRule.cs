using System;
using System.Collections.Generic;
using System.Text;
using TradesPortfolio.Entities;

namespace TradesPortfolio.UseCases.CategoryRules
{
    public abstract class CategoryRule
    {
        public abstract string GetRule(Trade trade, DateTime referenceDate);
    }
}
