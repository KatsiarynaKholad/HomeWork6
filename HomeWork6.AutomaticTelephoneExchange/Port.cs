using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6.AutomaticTelephoneExchange
{
    public delegate void PortStatusHandler(Port sender, PortStatusHandlerEventArgs eventArgs);
    public delegate void CallStatusHandler(string message, string numberPhoneWhichCall);

    public class Port
    {
        public event PortStatusHandler PortStatusEvent;
        public event CallStatusHandler CallStatusEvent;

        public bool ConnectByTelephone { get; private set; } = false;
        public bool TalkState { get; private set; } = false;

        public void Connect(Client client)
        {
            ConnectByTelephone = true;
            PortStatusEvent?.Invoke(this, new PortStatusHandlerEventArgs($"Client: {client.LastName} {client.FirstName} connected the telephone from the port"));
        }

        public void DisConnect(Client client)
        {
            ConnectByTelephone = false;
            PortStatusEvent?.Invoke(this, new PortStatusHandlerEventArgs($"Client: {client.LastName} {client.FirstName} DISCONNECTED the telephone from the port"));
        }

        public void MakeOutgoingCall(Client client, string numberPhoneWhichCall)
        {
            TalkState = true;
            CallStatusEvent?.Invoke($"Client: {client.LastName} {client.FirstName} called by number phone {numberPhoneWhichCall}", numberPhoneWhichCall);
        }

        public void MakeIncomingCall(string numberPhoneWhichCall, Telephone telephoneInterUser)
        {
            TalkState = true;
            telephoneInterUser.MakeIncomingCallByTelephone();
        }

        public void EndCall(Client client)
        {
            TalkState = false;
            PortStatusEvent?.Invoke(this, new PortStatusHandlerEventArgs($"Client: {client.LastName} {client.FirstName} ended the call"));
        }
    }
}
