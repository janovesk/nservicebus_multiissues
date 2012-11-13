using NServiceBus;

namespace SagaTest
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        private const string EndpointName = "Test";

        public void Init()
        {
            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);
            Configure.With()
                .DefineEndpointName(EndpointName)
                .Log4Net()
                .DefaultBuilder()               
                .XmlSerializer()
                .MsmqTransport()
                .IsolationLevel(System.Transactions.IsolationLevel.RepeatableRead)
                .Sagas()
                .RavenSagaPersister()
                .UseRavenTimeoutPersister()
                .RavenSubscriptionStorage()
                .UnicastBus()
                .DisableSecondLevelRetries();
        }
    }
}
