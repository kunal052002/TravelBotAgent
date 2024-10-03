namespace TravelBotAgent.DTOs.OutGoingTemplateMessageDTO
{
    public class OutGoingTemplateMessageDTO
    {
        public List<Message> messages;
    }
    public class Body
    {
        public List<string> placeholders { get; set; }
    }
    public class Button
    {
        public string type { get; set; }
        public string parameter { get; set; }
    }
    public class Header
    {
        public string type { get; set; }
        public string mediaUrl { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
    public class Content
    {
        public string templateName { get; set; }
        public TemplateData templateData { get; set; }
        public string language { get; set; }
    }
    public class Message
    {
        public string from { get; set; }
        public string to { get; set; }
        public string messageId { get; set; }
        public Content content { get; set; }
        public string callbackData { get; set; }
        public string notifyUrl { get; set; }
        public UrlOptions urlOptions { get; set; }
    }
    public class TemplateData
    {
        public Body body { get; set; }
        public List<Button> buttons { get; set; }
        public Header header { get; set; }
    }
    public class UrlOptions
    {
        public bool shortenUrl { get; set; }
        public bool trackClicks { get; set; }
        public string trackingUrl { get; set; }
        public bool removeProtocol { get; set; }
        public string customDomain { get; set; }
    }
}
