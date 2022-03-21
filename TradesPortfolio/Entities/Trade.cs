using System;
using System.Globalization;
using TradesPortfolio.Interfaces;

namespace TradesPortfolio.Entities
{
    public class Trade : ITrade
    {
        private readonly double _value;
        private readonly string _clientSector;
        private readonly DateTime _nextPaymentDate;

        public Trade(double value, string clientSector, DateTime nextPaymentDate)
        {
            _value = value;
            _clientSector = clientSector;
            _nextPaymentDate = nextPaymentDate;
        }

        public double Value => _value;
        public string ClientSector => _clientSector;
        public DateTime NextPaymentDate => _nextPaymentDate;

        public static Trade CreateTradeFromString(string input)
        {
            var values = input.Split(' ');

            double.TryParse(values[0], out double value);
            string clientSector = values[1];
            DateTime.TryParse(values[2], CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out DateTime nextPaymentDate);

            return new Trade(value, clientSector, nextPaymentDate);
        }
    }
}
