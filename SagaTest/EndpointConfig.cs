using NServiceBus;

namespace SagaTest
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        private const string EndpointName = "Test";

        public void Init()
        {
            InitializeServiceBus();
        }

        private void InitializeServiceBus()//IWindsorContainer container)
        {
            SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);
            Configure.With()
                .DefineEndpointName(EndpointName)
                .Log4Net()
                .DefaultBuilder()
                //.CastleWindsorBuilder(container)
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
