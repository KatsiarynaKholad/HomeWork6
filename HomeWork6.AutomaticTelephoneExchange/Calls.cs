using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6.AutomaticTelephoneExchange
{
    public class Calls
    {
        public Guid NumberOfCheck { get; }
        public string TargetTelephoneNumber { get; }
        public double Cost { get; set; }
        public DateTime StartCall { get; private set; }
        public DateTime EndCall { get; private set; }
        public int Duration { get; private set; }

        public Calls(string targetTelephoneNumber, Tariff tariff, DateTime start, DateTime end)
        {
            NumberOfCheck = Guid.NewGuid();
            Duration = (end - start).Seconds;
            TargetTelephoneNumber = targetTelephoneNumber;
            Cost = tariff.CostOfSecond * Duration;
        }
    }
}
