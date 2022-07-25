using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6.AutomaticTelephoneExchange
{
    public class Contract
    {
        public string NumberPhone { get; private set; }
        public Client Client { get; private set; }

        public Contract(Client client, string numberPhone)
        {
            Client = client;
            NumberPhone = numberPhone;
        }
    }
}
