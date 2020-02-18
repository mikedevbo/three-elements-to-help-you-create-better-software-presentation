using NServiceBus;

namespace Messages
{
    public class ProcessItemB : ICommand
    {
        public string ItemId { get; set; }
    }
}