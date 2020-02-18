using NServiceBus;

namespace Messages
{
    public class ProcessItemD : ICommand
    {
        public string ItemId { get; set; }
    }
}