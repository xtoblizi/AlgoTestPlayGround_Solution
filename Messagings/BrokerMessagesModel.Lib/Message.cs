using System;

namespace BrokerMessagesModel.Lib
{
    public class Message
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
