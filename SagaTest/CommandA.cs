using System;
using NServiceBus;

namespace SagaTest
{
    public interface CommandA : ICommand
    {
        Guid OrderId { get; set; }
    }
}