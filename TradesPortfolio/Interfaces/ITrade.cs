using System;
using System.Collections.Generic;
using System.Text;

namespace TradesPortfolio.Interfaces
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
    }
}
