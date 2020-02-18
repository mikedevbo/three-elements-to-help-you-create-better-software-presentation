using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace Server.A
{
    public class ProcessItemAHandler : IHandleMessages<ProcessItemA>
    {
        private static ILog log = LogManager.GetLogger<ProcessItemAHandler>();
        private static Random random = new Random();

        public async Task Handle(ProcessItemA message, IMessageHandlerContext context)
        {
            ////// Uncomment if you want to simulate timeout or deadlock exception
            ////if (random.Next(0, 5) == 0)
            ////{
            ////    throw new Exception("Timeout_Deadlock");
            ////}

            ////// Uncomment if you want to simulate bug exception
            ////throw new Exception("Bug");

            ////execute business logic

            log.Info($"ItemA processed: {message.ItemId}");

            //// Comment sending messages if you want to publish event
            await context.Send(new ProcessItemB { ItemId = message.ItemId }).ConfigureAwait(false);
            await context.Send(new ProcessItemC { ItemId = message.ItemId }).ConfigureAwait(false);
            await context.Send(new ProcessItemD { ItemId = message.ItemId }).ConfigureAwait(false);

            ////// Uncomment if you want to publish event
            ////// Add to Server project existing event handler if you want to see event procecssing
            ////await context.Publish<ItemAProcessed>(e => e.ItemId = message.ItemId).ConfigureAwait(false);
        }
    }
}
