using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6.AutomaticTelephoneExchange
{
    public class Client
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Telephone Telephone { get; set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; } 
        public List<Calls> CallsHistory { get; set; }

        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            CallsHistory = new List<Calls>();

        }

        public void AssignTelephone(Telephone telephone)
        {
            Telephone = telephone;
        }

        public void GetCalled(Client client, string numberPhoneWhichCall, Tariff tariff)
        {
            Telephone.MakeOutgoingCallToPort(client, numberPhoneWhichCall);
            CallsHistory.Add(new Calls(numberPhoneWhichCall, tariff, Start, End));
            Start = DateTime.Now;

        }

        public void EndCall(Client client)
        {
            Telephone.EndCallToPort(client);
            End = DateTime.Now.AddSeconds(new Random().Next(250));
        }

        public void DisconnectTelephoneToPort(Client client)
        {
            Telephone.DisConnectToPort(client);
        }
    }
}
