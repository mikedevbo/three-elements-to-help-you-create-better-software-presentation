using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace Server.A
{
    public class ProcessItemDHandler : IHandleMessages<ProcessItemD>
    {
        private static ILog log = LogManager.GetLogger<ProcessItemDHandler>();

        public Task Handle(ProcessItemD message, IMessageHandlerContext context)
        {
            ////execute business logic

            log.Info($"ItemD processed: {message.ItemId}");
            return Task.CompletedTask;
        }
    }
}
