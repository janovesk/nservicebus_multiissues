using System;
using System.Threading;
using NServiceBus.Saga;

namespace SagaTest
{
    public class Saga : Saga<SagaData>, IAmStartedByMessages<CommandA>, IAmStartedByMessages<CommandB>
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<CommandA>(s => s.OrderId, m => m.OrderId);
            ConfigureMapping<CommandB>(s => s.OrderId, m => m.OrderId);
        }
        
        public void Handle(CommandA command)
        {
            Console.WriteLine(GetThreadName() + "CommmandA. OrderId in command " + command.OrderId);
            Console.WriteLine(GetThreadName() + "CommmandA. OrderId from sagadata " + Data.OrderId);
            Data.OrderId = command.OrderId;
            Data.GotA = true;
            TryFinish();
        }

        public void Handle(CommandB command)
        {
            Console.WriteLine(GetThreadName() + "CommandB. OrderId in command " + command.OrderId);
            Console.WriteLine(GetThreadName() + "CommandB. OrderId from sagadata " + Data.OrderId);
            Data.OrderId = command.OrderId;
            Data.GotB = true;
            TryFinish();
        }

        private void TryFinish()
        {
            if (Data.GotA && Data.GotB)
            {
                Console.WriteLine("Saga got all data. Order Id " + Data.OrderId + "complete.");
                MarkAsComplete();
            }
        }

        private static string GetThreadName()
        {
            return "[" + Thread.CurrentThread.Name + "] ";
        }
    }
}