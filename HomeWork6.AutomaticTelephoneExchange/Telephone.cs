using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6.AutomaticTelephoneExchange
{
    public delegate void CallStatusByPhoneHandler(Telephone sender, CallStatusByPhoneHandlerEvenArgs evenArgs);
    public class Telephone
    {
        public event CallStatusByPhoneHandler CallStatusByPhoneEvent;
        public Port Port { get; set; }

        public void TelephoneState(Port port)
        {
            Port = port;
        }

        public void ConnectToPort(Client client)
        {
            if (Port.ConnectByTelephone)
            {
                Console.WriteLine("The telephone is already connected to the port");
            }
            else
            {
                Port.Connect(client);
            }
        }

        public void DisConnectToPort(Client client)
        {
            if (Port.ConnectByTelephone)
            {
                Port.DisConnect(client);
            }
            else
            {
                Console.WriteLine("Telephone is already disconnect to the port");
            }
        }

        public void MakeOutgoingCallToPort(Client client, string numberPhoneWhichCall)
        {
            if (Port.ConnectByTelephone)
            {
                if (numberPhoneWhichCall != null)
                {
                    Port.MakeOutgoingCall(client, numberPhoneWhichCall);
                }
                else
                {
                    Console.WriteLine("You didn't enter a number phone, so call can not be made");
                }
            }
            else
            {
                Console.WriteLine("Telephone isn't connect with port");
            }
        }

        public void MakeIncomingCallByTelephone()
        {
            CallStatusByPhoneEvent?.Invoke(this, new CallStatusByPhoneHandlerEvenArgs($"Client received an incoming call"));
        }

        public void EndCallToPort(Client client)
        {
            Port.EndCall(client);
        }
    }
}