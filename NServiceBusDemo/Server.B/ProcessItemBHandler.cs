using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace Server.B
{
    public class ProcessItemBHandler : IHandleMessages<ProcessItemB>
    {
        private static ILog log = LogManager.GetLogger<ProcessItemBHandler>();

        public Task Handle(ProcessItemB message, IMessageHandlerContext context)
        {
            ////execute business logic

            log.Info($"ItemB processed: {message.ItemId}");
            return Task.CompletedTask;
        }
    }
}
