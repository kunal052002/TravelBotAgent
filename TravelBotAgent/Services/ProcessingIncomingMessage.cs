using TravelBotAgent.DTOs.OutGoingTemplateMessageDTO;
using TravelBotAgent.DTOs;
using TravelBotAgent.Helper;
using TravelBotAgent.Interface;
using TravelBotAgent.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace TravelBotAgent.Services
{
    public class ProcessingIncomingMessage : IProcessingIncomingMessage
    {
        private readonly IPrepareOutGoingDtos _prepareOutGoingDtos;
        private readonly ISendMessage _sendMessage;
        private readonly TravelBotNewContext _travelBotNewContext;
        private readonly ICreatePDF _createPDF;

        public ProcessingIncomingMessage(IPrepareOutGoingDtos prepareOutGoingDtos, ISendMessage sendMessage, TravelBotNewContext travelBotNewContext,ICreatePDF createPDF)
        {
            _prepareOutGoingDtos = prepareOutGoingDtos;
            _sendMessage = sendMessage;
            _travelBotNewContext = travelBotNewContext;
            _createPDF = createPDF;
        }


        public async Task CreateMessage(IncomingMessageDto incomingMessageDto)
        {

            var CheckSession = await _travelBotNewContext.Sessions.FirstOrDefaultAsync(s => s.MobileNumber == incomingMessageDto.results[0].from);
            var IncomingTextMessage = incomingMessageDto.results[0].message.text;
            var IncomingSender = incomingMessageDto.results[0].from;
            async Task RetrieveMessage(int id)
            {
                //Console.WriteLine("Inside RetrieveMessage with id ", id);
                Question question = await _travelBotNewContext.Questions.FindAsync(id);
                //Console.WriteLine("Sending question ", question);
                OutGoingMessageDto outGoingMessageDto = await _prepareOutGoingDtos.CreateMessage(incomingMessageDto, question);
                await _sendMessage.SendTextMessage(outGoingMessageDto);
            }
            if (CheckSession != null)
            {
                if (IncomingTextMessage.ToLower() =="exit")
                {
                    var IsDelete = await _travelBotNewContext.Sessions.FirstOrDefaultAsync(e => e.MobileNumber == IncomingSender);
                    if (IsDelete != null)
                    {
                        await RetrieveMessage(12);
                        _travelBotNewContext.Sessions.Remove(IsDelete);
                        await _travelBotNewContext.SaveChangesAsync();
                        return;
                    }
                    return;
                }
                switch (CheckSession.QuestionId)
                {
                    case 1:
                        if (IncomingTextMessage == Resources.GetEnumDescription(Resources.FirstChoice.FlightChoice))
                        {
                            Question question = _travelBotNewContext.Questions.Find(2);
                            OutGoingMessageDto outGoingMessageDto = await _prepareOutGoingDtos.CreateMessage(incomingMessageDto,question);
                            await _sendMessage.SendTextMessage(outGoingMessageDto);
                            CheckSession.QuestionId = 2;
                            await _travelBotNewContext.SaveChangesAsync();
                            return;

                        }

                        if (IncomingTextMessage == Resources.GetEnumDescription(Resources.FirstChoice.HotelChoice))
                        {
                            Question question =  await _travelBotNewContext.Questions.FindAsync(6);
                            OutGoingMessageDto outGoingMessageDto = await _prepareOutGoingDtos.CreateMessage(incomingMessageDto, question);
                            await _sendMessage.SendTextMessage(outGoingMessageDto);
                            CheckSession.QuestionId = 6;
                            await _travelBotNewContext.SaveChangesAsync();
                            return;
                        }

                        if (IncomingTextMessage == Resources.GetEnumDescription(Resources.FirstChoice.HolidayChoice))
                        {
                            Question question = await _travelBotNewContext.Questions.FindAsync(13);
                            OutGoingMessageDto outGoingMessageDto = await _prepareOutGoingDtos.CreateMessage(incomingMessageDto, question);
                            await _sendMessage.SendTextMessage(outGoingMessageDto);
                            CheckSession.QuestionId = 13;
                            await _travelBotNewContext.SaveChangesAsync();
                            return;
                        }

                        else
                        {   //Invalid input alert.
                            await RetrieveMessage(9);
                        }

                        break;

                    case 2://For Flight Booking
                        if(IncomingTextMessage == "1")
                        {
                            //Console.WriteLine("Inside Case 2");
                            await RetrieveMessage(3);
                            CheckSession.QuestionId = 3;
                            await _travelBotNewContext.SaveChangesAsync();
                            return;
                        }
                        if (IncomingTextMessage == "2")
                        {
                            await RetrieveMessage(4);
                            CheckSession.QuestionId = 3;
                            await _travelBotNewContext.SaveChangesAsync();
                            return;
                        }
                        if (IncomingTextMessage == "3")
                        {
                            await RetrieveMessage(5);
                            CheckSession.QuestionId = 3;
                            await _travelBotNewContext.SaveChangesAsync();
                            return;
                        }
                        else
                        {
                            await RetrieveMessage(9);
                            return;
                        }
                        break;
                        

                    case 6://for Hotel Booking
                        if(IncomingTextMessage == "1")
                        {   //Pune's hotel
                            await RetrieveMessage(7);
                            CheckSession.QuestionId = 7;
                            await _travelBotNewContext.SaveChangesAsync();
                            return;
                        }

                        if (IncomingTextMessage == "2")
                        {   //Mumbai's Hotel
                            await RetrieveMessage(8);
                            CheckSession.QuestionId = 7;
                            await _travelBotNewContext.SaveChangesAsync();
                            return;
                        }

                        if (IncomingTextMessage == "3")
                        {   //Bangalore's Hotel
                            await RetrieveMessage(11);
                            CheckSession.QuestionId = 7;
                            await _travelBotNewContext.SaveChangesAsync();
                            return; 
                        }
                        else
                        {   //Invalid input alert
                            await RetrieveMessage(9);
                            return;
                        }

                    case 3://For Flight Booking
                        if(IncomingTextMessage == "1")
                        {
                            OutGoingTemplateMessageDTO outGoingTemplateMessageDTO = await _prepareOutGoingDtos.CreateOutGoingBoardingPassTemplate(incomingMessageDto);
                            await _sendMessage.SendMessageTemplate(outGoingTemplateMessageDTO);
                            return;
                        }
                        if (IncomingTextMessage == "2")
                        {
                            OutGoingTemplateMessageDTO outGoingTemplateMessageDTO = await _prepareOutGoingDtos.CreateOutGoingBoardingPassTemplate(incomingMessageDto);
                            await _sendMessage.SendMessageTemplate(outGoingTemplateMessageDTO);
                            return;
                        }
                        if (IncomingTextMessage == "3")
                        {
                            OutGoingTemplateMessageDTO outGoingTemplateMessageDTO = await _prepareOutGoingDtos.CreateOutGoingBoardingPassTemplate(incomingMessageDto);
                            await _sendMessage.SendMessageTemplate(outGoingTemplateMessageDTO);
                            return;
                        }
                        else
                        {   //Invalid input alert
                            await RetrieveMessage(9);
                            return;
                        }
                        break;

                    case 7://Hotel Booking
                        if(IncomingTextMessage == "1" || IncomingTextMessage == "2" || IncomingTextMessage == "3")
                        {
                            OutGoingTemplateMessageDTO outGoingTemplateMessageDTO =  _prepareOutGoingDtos.CreateOutGoingLocationTemplate(incomingMessageDto);
                            await _sendMessage.SendMessageTemplate(outGoingTemplateMessageDTO);
                            return;
                        }

                        else
                        {   //Invalid input alert
                            await RetrieveMessage(9);
                            return;
                        }
                        break ;

                        case 13://For Holiday Package
                            if(IncomingTextMessage=="1")
                        {
                            Question data = await _travelBotNewContext.Questions.FindAsync(14);
                            string pdf_data = data.QuestionData;
                            byte[] pdf = _createPDF.GeneratePDF(pdf_data);

                            var folder = "Doc/";
                            var pdfName = Guid.NewGuid().ToString() + ".pdf";
                            var pdfPath = folder + pdfName;


                            //OutGoingTemplateMessageDTO outGoingTemplateMessageDTO = await _prepareOutGoingDtos.CreateOutGoingPDFTemplate(incomingMessageDto);
                            //_createPDF.SavePDFLocally(pdf, "C:\\Users\\Kunal.thakare\\Documents\\Holiday_package_PD1.pdf");
                            _createPDF.SavePDFLocally(pdf, pdfPath);

                            var pdfURL = "https://p0c51xdw-7099.inc1.devtunnels.ms/Doc" + pdfName + ".pdf";
                            OutGoingTemplateMessageDTO outGoingTemplateMessageDTO =  _prepareOutGoingDtos.CreateOutGoingPDFTemplate(incomingMessageDto);

                        }    //"C:\Users\Kunal.thakare\Documents\Holiday_package_PDF"
                        break ;

                    default:
                        break;
                }

            }
            else
            {
                if (IncomingTextMessage.ToLower() == Resources.InitialMessage.hi.ToString())
                {
                    OutGoingTemplateMessageDTO outGoingTemplateMessageDTO = await _prepareOutGoingDtos.CreateOutGoingTempleteMessage(incomingMessageDto);
                    await _sendMessage.SendMessageTemplate(outGoingTemplateMessageDTO);
                    var CreateSession = new Session
                    {
                        MobileNumber = incomingMessageDto.results[0].from,
                        IsActive = true,
                        QuestionId = 1
                    };
                    _travelBotNewContext.Sessions.Add(CreateSession);
                    await _travelBotNewContext.SaveChangesAsync();
                    return;
                }
                else
                {
                    await RetrieveMessage(10);
                    return;
                }

            }


            return;
        }
    }
}
