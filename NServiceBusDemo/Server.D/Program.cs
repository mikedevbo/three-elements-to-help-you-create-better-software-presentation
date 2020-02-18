using Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Server.D
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            const string endpointName = "Server.D";

            Console.Title = endpointName;

            var endpointConfiguration = new EndpointConfiguration(endpointName);

            ////// uncomment if you want to disable delayed retries
            ////endpointConfiguration.Recoverability().Delayed(custom => custom.NumberOfRetries(0));

            endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.UsePersistence<LearningPersistence>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            ////// uncomment if you want to unsubscribe event
            ////await endpointInstance.Unsubscribe<ItemAProcessed>().ConfigureAwait(false);

            Console.WriteLine("Ready");
            Console.ReadKey();

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
