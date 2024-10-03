namespace TravelBotAgent.DTOs
{
  
        public class IncomingMessageDto
        {
            public Result[] results { get; set; }
            public int messageCount { get; set; }
            public int pendingMessageCount { get; set; }
        }

        public class Result
        {
            public string from { get; set; }
            public string to { get; set; }
            public string integrationType { get; set; }
            public DateTime receivedAt { get; set; }
            public string messageId { get; set; }
            public object pairedMessageId { get; set; }
            public object callbackData { get; set; }
            public Message message { get; set; }
            public Contact contact { get; set; }
            public Price price { get; set; }
        }

        public class Message
        {
            public string type { get; set; }
            public string text { get; set; }
            public string caption { get; set; }
            public string url { get; set; }
            public double longitude { get; set; }
            public double latitude { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public string mediaURL { get; set; }
        }

        public class Contact
        {
            public string name { get; set; }
        }

        public class Price
        {
            public float pricePerMessage { get; set; }
            public string currency { get; set; }
        }
    
}
