using TravelBotAgent.DTOs;

namespace TravelBotAgent.Interface
{
    public interface IProcessingIncomingMessage
    {
        public Task CreateMessage(IncomingMessageDto incomingMessageDto);
    }
}
