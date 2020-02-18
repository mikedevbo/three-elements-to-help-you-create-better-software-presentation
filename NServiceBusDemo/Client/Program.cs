using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        private static ILog log = LogManager.GetLogger<Program>();

        public static async Task Main(string[] args)
        {
            const string endpointName = "Client";

            Console.Title = endpointName;

            var endpointConfiguration = new EndpointConfiguration(endpointName);

            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.UsePersistence<LearningPersistence>();

            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(ProcessItemA), "Server.A");

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            var continueLooping = true;
            while (continueLooping)
            {
                log.Info("Press 'P' to send message, or 'Q' to quit.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        var message = new ProcessItemA { ItemId = Guid.NewGuid().ToString() };
                        await endpointInstance.Send(message).ConfigureAwait(false);
                        log.Info($"Sent ItemA: {message.ItemId}");
                        break;

                    case ConsoleKey.Q:
                        continueLooping = false;
                        break;
                    default:
                        log.Info("Unknown input. Please try again.");
                        break;
                }
            }

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
