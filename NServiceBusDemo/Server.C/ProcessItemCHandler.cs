using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace Server.C
{
    public class ProcessItemCHandler : IHandleMessages<ProcessItemC>
    {
        private static ILog log = LogManager.GetLogger<ProcessItemCHandler>();

        public Task Handle(ProcessItemC message, IMessageHandlerContext context)
        {
            ////execute business logic

            log.Info($"ItemC processed: {message.ItemId}");
            return Task.CompletedTask;
        }
    }
}
