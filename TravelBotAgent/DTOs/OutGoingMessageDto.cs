namespace TravelBotAgent.DTOs
{
    public class OutGoingMessageDto
    {
        public string from { get; set; }
        public string to { get; set; }
        public string messageId { get; set; } = "";
        public Content content { get; set; }
        public string callbackData { get; set; } = "";
        public string notifyUrl { get; set; } = "";

        public class Content
        {
            public string text { get; set; } = "";
            public string mediaUrl { get; set; } = "";
        }
    }
}
