using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWork6.AutomaticTelephoneExchange
{
    public class Tariff
    {
        public string Name { get; private set; }
        public double CostOfSecond { get; private set; }

        public static readonly Tariff Light = new Tariff(TariffType.Light.ToString(), 0.8);
        public static readonly Tariff Standart = new Tariff(TariffType.Standart.ToString(), 0.4);
        public static readonly Tariff Premium = new Tariff(TariffType.Premium.ToString(), 0.2);

        public Tariff(string name, double cost)
        {
            Name = name;
            CostOfSecond = cost;
        }
    }
}