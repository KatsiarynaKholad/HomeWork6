using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6.AutomaticTelephoneExchange
{
    public class ATE
    {
        public List<Contract> Contracts { get; set; }
        public List<Port> Ports { get; set; }
        public List<Telephone> Telephones { get; set; }

        public ATE()
        {
            Contracts = new List<Contract>();
            Ports = new List<Port>();
            Telephones = new List<Telephone>();
        }

        public Contract NewContract(Client client)
        {
            Contract contract = new Contract(client, "+37529" + new Random().Next(1111111, 9999999).ToString());
            Contracts.Add(contract);
            var port = new Port();
            Ports.Add(port);
            port.PortStatusEvent += PrintMessage;
            port.CallStatusEvent += PortCallEvent;
            var telephone = new Telephone();
            Telephones.Add(telephone);
            telephone.CallStatusByPhoneEvent += PrintMessageByPhone;
            return contract;
        }

        private static void PrintMessageByPhone(Telephone sender, CallStatusByPhoneHandlerEvenArgs evenArgs)
        {
            Console.WriteLine(evenArgs.Message);
        }

        private static void PrintMessage(Port sender, PortStatusHandlerEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Message);
        }

        private void PortCallEvent(string message, string phoneNumber)
        {
            Console.WriteLine(message);
            var indexSubscriber = Contracts.FindIndex(x => x.NumberPhone == phoneNumber);

            if (indexSubscriber == -1)
            {
                Console.WriteLine("A call can not be made. You enter a wrong phone number.");
            }
            else if (Ports[indexSubscriber].ConnectByTelephone == true)
            {
                if (Ports[indexSubscriber].TalkState == false)
                {
                    Ports[indexSubscriber].MakeIncomingCall(phoneNumber, Telephones[indexSubscriber]);
                }
                else
                {
                    Console.WriteLine("Line is busy.");
                }
            }
            else
            {
                Console.WriteLine("The subscriber terminal is not connected to the port.");
            }
        }

        public Telephone GetTelephone(Contract contract)
        {
            var index = Contracts.FindIndex(x => x == contract);
            return Telephones[index];
        }

        public Port GetPort(Contract contract)
        {
            var index = Contracts.FindIndex(x => x == contract);
            return Ports[index];
        }
    }
}
