using Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Server.A
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            const string endpointName = "Server.A";

            Console.Title = endpointName;

            var endpointConfiguration = new EndpointConfiguration(endpointName);

            ////// uncomment if you want to disable delayed retries
            ////endpointConfiguration.Recoverability().Delayed(custom => custom.NumberOfRetries(0));

            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.UsePersistence<LearningPersistence>();

            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(ProcessItemB), "Server.B");
            routing.RouteToEndpoint(typeof(ProcessItemC), "Server.C");
            routing.RouteToEndpoint(typeof(ProcessItemD), "Server.D");

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            Console.WriteLine("Ready");
            Console.ReadKey();

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
