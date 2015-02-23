namespace UserService.Web
{
    using NServiceBus;

    public static class ServiceBus
    {
        #region Public Properties

        public static IBus Bus { get; private set; }

        #endregion

        #region Public Methods and Operators

        public static void Init()
        {
            if (Bus != null)
            {
                return;
            }

            lock (typeof(ServiceBus))
            {
                if (Bus != null)
                {
                    return;
                }

                var configuration = new BusConfiguration();
                configuration.EndpointName("UserService.Web");
                configuration.PurgeOnStartup(true);
                configuration.UsePersistence<InMemoryPersistence>();
                configuration.UseTransport<MsmqTransport>();

                Bus = NServiceBus.Bus.Create(configuration);
            }
        }

        #endregion
    }
}