using NServiceBus;

namespace Messages
{
    public class ProcessItemC : ICommand
    {
        public string ItemId { get; set; }
    }
}