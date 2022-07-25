namespace HomeWork6.AutomaticTelephoneExchange
{
    public class PortStatusHandlerEventArgs
    {
        public string Message { get; }

        public PortStatusHandlerEventArgs(string message)
        {
            Message = message;
        }
    }
}