using NServiceBus;

namespace Messages
{
    public class ProcessItemA : ICommand
    {
        public string ItemId { get; set; }
    }
}