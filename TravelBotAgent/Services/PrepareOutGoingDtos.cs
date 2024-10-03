using TravelBotAgent.DTOs.OutGoingTemplateMessageDTO;
using TravelBotAgent.DTOs;
using TravelBotAgent.Interface;
using TravelBotAgent.Models;

namespace TravelBotAgent.Services
{
    public class PrepareOutGoingDtos : IPrepareOutGoingDtos
    {
        private readonly IConfiguration _configuration;

        public PrepareOutGoingDtos(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<OutGoingMessageDto> CreateMessage(IncomingMessageDto incomingMessageDto, Question question)
        {   //Here we convert the IncomingMessageDto into the OutGoingMessageDto
            string formattedMessage = question.QuestionData.Replace("\n", " ");
            var OutGoingMessageDto1 = new OutGoingMessageDto
            {
                from = _configuration["Infobip:RegisteredNumber"],
                to = incomingMessageDto.results[0].from,
                content = new OutGoingMessageDto.Content
                {
                    text = formattedMessage
                }
            };
            return OutGoingMessageDto1;
        }

        public async Task<OutGoingTemplateMessageDTO> CreateOutGoingBoardingPassTemplate(IncomingMessageDto incomingMessageDto)
        {
            {
                {
                    var messageFrom = _configuration["Infobip:RegisteredNumber"];
                    var messageTo = incomingMessageDto.results[0].from;


                    string templateName = "boarding_pass";

                    var messagelist = new List<TravelBotAgent.DTOs.OutGoingTemplateMessageDTO.Message>();


                    var body = new Body
                    {
                        placeholders = new List<string> { "100"}

                    };
                    
                    var header = new Header
                    {
                        type = "IMAGE",
                        mediaUrl = "https://planetofthepaul.com/wp-content/uploads/2023/01/3-1536x864.jpg"
                    };


                    messagelist.Add(new DTOs.OutGoingTemplateMessageDTO.Message
                    {
                        from = messageFrom,
                        to = messageTo,
                        messageId = Guid.NewGuid().ToString(),
                        content = new DTOs.OutGoingTemplateMessageDTO.Content
                        {
                            templateName = templateName,
                            templateData = new TemplateData
                            {
                                body = body,
                                header = header
                            },
                            language = "en"
                        },
                        callbackData = "Callback Data",
                        notifyUrl = string.Empty
                    });

                    var templateMessage = new OutGoingTemplateMessageDTO
                    {
                        messages = messagelist,
                    };

                    return templateMessage;
                }
                throw new NotImplementedException();
            }
        }

        public OutGoingTemplateMessageDTO CreateOutGoingLocationTemplate(IncomingMessageDto incomingMessageDto)
        {
            {
                var messageFrom = _configuration["Infobip:RegisteredNumber"];
                var messageTo = incomingMessageDto.results[0].from;
                var receiverName = incomingMessageDto.results[0].contact.name;


                var latitude = _configuration["Location:latitude"];
                var longitude = _configuration["Location:longitude"];

                string templateName = "tb_hotel_location";

                var messagelist = new List<TravelBotAgent.DTOs.OutGoingTemplateMessageDTO.Message>();

                var body = new Body
                {
                    placeholders = new List<string> { }

                };

                var header = new Header
                {
                    type = "LOCATION",
                    latitude = Convert.ToDouble(latitude),
                    longitude = Convert.ToDouble(longitude)
                };


                messagelist.Add(new DTOs.OutGoingTemplateMessageDTO.Message
                {
                    from = messageFrom,
                    to = messageTo,
                    messageId = Guid.NewGuid().ToString(),
                    content = new DTOs.OutGoingTemplateMessageDTO.Content
                    {
                        templateName = templateName,
                        templateData = new TemplateData
                        {
                            body = body,
                            header = header
                        },
                        language = "en"
                    },
                    callbackData = "Callback Data",
                    notifyUrl = string.Empty
                });

                var templateMessage = new OutGoingTemplateMessageDTO
                {
                    messages = messagelist,
                };

                return templateMessage;
            }
            throw new NotImplementedException();
        }

        public OutGoingTemplateMessageDTO CreateOutGoingPDFTemplate(IncomingMessageDto incomingMessageDto)
        {
            {
                {
                    {
                        var messageFrom = _configuration["Infobip:RegisteredNumber"];
                        var messageTo = incomingMessageDto.results[0].from;


                        string templateName = "tb_pdf";

                        var messagelist = new List<TravelBotAgent.DTOs.OutGoingTemplateMessageDTO.Message>();


                        var body = new Body
                        {
                            placeholders = new List<string> { }

                        };

                        var header = new Header
                        {
                            type = "DOCUMENT",
                            mediaUrl = "https://planetofthepaul.com/wp-content/uploads/2023/01/3-1536x864.jpg"
                        };


                        messagelist.Add(new DTOs.OutGoingTemplateMessageDTO.Message
                        {
                            from = messageFrom,
                            to = messageTo,
                            messageId = Guid.NewGuid().ToString(),
                            content = new DTOs.OutGoingTemplateMessageDTO.Content
                            {
                                templateName = templateName,
                                templateData = new TemplateData
                                {
                                    body = body,
                                    header = header
                                },
                                language = "en"
                            },
                            callbackData = "Callback Data",
                            notifyUrl = string.Empty
                        });

                        var templateMessage = new OutGoingTemplateMessageDTO
                        {
                            messages = messagelist,
                        };

                        return templateMessage;
                    }
                    throw new NotImplementedException();
                }
            }
        }

        public async Task<OutGoingTemplateMessageDTO> CreateOutGoingTempleteMessage(IncomingMessageDto incomingMessageDto)
        {
            {
                var messageFrom = _configuration["Infobip:RegisteredNumber"];
                var messageTo = incomingMessageDto.results[0].from;
                var receiverName = incomingMessageDto.results[0].contact.name;




                string templateName = "tb_welcome";

                var messagelist = new List<TravelBotAgent.DTOs.OutGoingTemplateMessageDTO.Message>();

                var body = new Body
                {
                    placeholders = new List<string> { receiverName }

                };

                var button = new List<Button>
                {
                    
                   new Button
                   {
                       type = "QUICK_REPLY",
                       parameter = "1.Flight Booking"
                   },
                   new Button
                   {
                       type = "QUICK_REPLY",
                       parameter = "2.Hotel Booking"
                   },
                   new Button
                   {
                       type = "QUICK_REPLY",
                       parameter = "3.Holiday Package"
                   }
                };


                messagelist.Add(new DTOs.OutGoingTemplateMessageDTO.Message
                {
                    from = messageFrom,
                    to = messageTo,
                    messageId = Guid.NewGuid().ToString(),
                    content = new DTOs.OutGoingTemplateMessageDTO.Content
                    {
                        templateName = templateName,
                        templateData = new TemplateData
                        {
                            body = body,
                            buttons = button
                        },
                        language = "en"
                    },
                    callbackData = "Callback Data",
                    notifyUrl = string.Empty
                });

                var templateMessage = new OutGoingTemplateMessageDTO
                {
                    messages = messagelist,
                };

                return templateMessage;
            }
            throw new NotImplementedException();
        }
    }
}
