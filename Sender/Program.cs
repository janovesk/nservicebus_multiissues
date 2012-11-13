using System;
using NServiceBus;
using SagaTest;

namespace Sender
{
    public class Program
    {
        private const string Queuename = "Test";

        static void Main()
        {
            var bus = Configure.With()
                .DefaultBuilder()
                .XmlSerializer()
                .MsmqTransport()
                .UnicastBus()
                .SendOnly();

            Console.WriteLine("Press any key to generate data.");
            while(true)
            {
                Console.ReadLine();
                var guid = Guid.NewGuid();

                bus.Send<CommandA>(Queuename, m =>
                {
                    m.OrderId = guid;
                });
                Console.WriteLine("Sent CommandA for " + guid.ToString());

                bus.Send<CommandB>(Queuename, m =>
                {
                    m.OrderId = guid;
                });
                Console.WriteLine("Sent CommandB for " + guid.ToString());

            }
        }
    }
}
