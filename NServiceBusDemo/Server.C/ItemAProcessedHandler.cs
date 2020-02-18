using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace Server.C
{
    public class ItemAProcessedHandler : IHandleMessages<ItemAProcessed>
    {
        private static ILog log = LogManager.GetLogger<ItemAProcessedHandler>();

        public Task Handle(ItemAProcessed message, IMessageHandlerContext context)
        {
            log.Info($"received event: {nameof(ItemAProcessed)} {message.ItemId}");

            ////execute business logic

            log.Info($"ItemC processed: {message.ItemId}");
            return Task.CompletedTask;
        }
    }
}
