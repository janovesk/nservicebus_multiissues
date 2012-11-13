using System;
using NServiceBus.Saga;

namespace SagaTest
{
    public class SagaData : IContainSagaData
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }

        [Unique]
        public Guid OrderId { get; set; }
        public bool GotA { get; set; }
        public bool GotB { get; set; }
    }
}
