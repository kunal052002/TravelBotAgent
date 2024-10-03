using TravelBotAgent.DTOs.OutGoingTemplateMessageDTO;
using TravelBotAgent.DTOs;

namespace TravelBotAgent.Interface
{
    public interface ISendMessage
    {
        Task<HttpResponseMessage> SendMessageTemplate(OutGoingTemplateMessageDTO outGoingTemplateMessageDTO);

        Task<HttpResponseMessage> SendTextMessage(OutGoingMessageDto outGoingMessageDto);
    }
}
