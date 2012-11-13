using System;
using NServiceBus;

namespace SagaTest
{
    public interface CommandB: ICommand
    {
        Guid OrderId { get; set; }
    }
}
