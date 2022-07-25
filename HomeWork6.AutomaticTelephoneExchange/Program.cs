using System.Text;
namespace HomeWork6.AutomaticTelephoneExchange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATE ate = new ATE();

            Client client1 = new Client("Vasia", "Pupkin");
            Contract contract1 = ate.NewContract(client1);
            client1.AssignTelephone(ate.GetTelephone(contract1));
            client1.Telephone.TelephoneState(ate.GetPort(contract1));
            client1.Telephone.ConnectToPort(client1);

            Thread.Sleep(100);
            Client client2 = new Client("Petya", "Sidorov");
            Contract contract2 = ate.NewContract(client2);
            client2.AssignTelephone(ate.GetTelephone(contract2));
            client2.Telephone.TelephoneState(ate.GetPort(contract2));
            client2.Telephone.ConnectToPort(client2);

            Thread.Sleep(100);
            Client client3 = new Client("Banya", "Ivanov");
            Contract contract3 = ate.NewContract(client3);
            client3.AssignTelephone(ate.GetTelephone(contract3));
            client3.Telephone.TelephoneState(ate.GetPort(contract3));
            client3.Telephone.ConnectToPort(client3);

            var sortedClient = ate.Contracts.OrderBy(n => n.Client.LastName).ToList();
            foreach (var item in sortedClient)
            {
                Console.WriteLine($"{item.Client.LastName} {item.Client.FirstName} - {item.NumberPhone}");
            }

            Thread.Sleep(1000);
            client1.GetCalled(client1, contract2.NumberPhone, Tariff.Light);

            Thread.Sleep(1000);
            client3.GetCalled(client3, contract2.NumberPhone, Tariff.Premium);

            Thread.Sleep(1000);
            client1.EndCall(client1);
            client1.DisconnectTelephoneToPort(client1);
            client2.EndCall(client2);

            client3.GetCalled(client2, contract2.NumberPhone, Tariff.Standart);


            client3.EndCall(client3);
            client2.EndCall(client2);
            client3.DisconnectTelephoneToPort(client3);
            client3.DisconnectTelephoneToPort(client3);

            var call1 = new Calls(contract1.NumberPhone, Tariff.Light, client1.Start, client1.End);
            var call2 = new Calls(contract2.NumberPhone, Tariff.Premium, client2.Start, client2.End);
            var call3 = new Calls(contract3.NumberPhone, Tariff.Standart, client3.Start, client3.End);

            var filePath = @"D:\Check.txt";

            using (var sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine($"Check: {call1.NumberOfCheck} \tClient: {client1.LastName} {client1.FirstName} with phone number:{call1.TargetTelephoneNumber}, you need to pay: {call1.Cost.ToString("###.####")} (you spent {call1.Duration} seconds)");
                sw.WriteLine($"Check: {call2.NumberOfCheck} \tClient: {client2.LastName} {client2.FirstName} with phone number:{call2.TargetTelephoneNumber}, you need to pay: {call2.Cost.ToString("###.####")} (you spent {call2.Duration} seconds)");
                sw.WriteLine($"Check: {call3.NumberOfCheck} \tClient: {client3.LastName} {client3.FirstName} with phone number:{call3.TargetTelephoneNumber}, you need to pay: {call3.Cost.ToString("###.####")} (you spent {call3.Duration} seconds)");

            }
        }
    }
}
