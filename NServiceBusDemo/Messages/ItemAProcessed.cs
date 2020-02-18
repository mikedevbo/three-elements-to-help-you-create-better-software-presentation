using NServiceBus;

namespace Messages
{
    public class ItemAProcessed : IEvent
    {
        public string ItemId { get; set; }
    }
}
