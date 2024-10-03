using TravelBotAgent.DTOs.OutGoingTemplateMessageDTO;
using TravelBotAgent.DTOs;
using TravelBotAgent.Models;

namespace TravelBotAgent.Interface
{
    public interface IPrepareOutGoingDtos
    {
        Task<OutGoingTemplateMessageDTO> CreateOutGoingTempleteMessage(IncomingMessageDto incomingMessageDto);

        Task<OutGoingMessageDto> CreateMessage(IncomingMessageDto incomingMessageDto,Question question);
        OutGoingTemplateMessageDTO CreateOutGoingLocationTemplate(IncomingMessageDto incomingMessageDto);
        Task<OutGoingTemplateMessageDTO> CreateOutGoingBoardingPassTemplate(IncomingMessageDto incomingMessageDto);
        OutGoingTemplateMessageDTO CreateOutGoingPDFTemplate(IncomingMessageDto incomingMessageDto);
    }
}
