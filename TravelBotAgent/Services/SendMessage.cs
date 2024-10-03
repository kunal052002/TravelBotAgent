using System.Text;
using TravelBotAgent.DTOs.OutGoingTemplateMessageDTO;
using TravelBotAgent.DTOs;
using TravelBotAgent.Interface;
using Newtonsoft.Json;

namespace TravelBotAgent.Services
{

    public class SendMessage : ISendMessage
    {
        private readonly IConfiguration _configuration;

        public SendMessage(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<HttpResponseMessage> SendMessageTemplate(OutGoingTemplateMessageDTO outGoingTemplateMessageDTO)
        {
            var BaseURL = _configuration["Infobip:InfobipBaseURL"] + _configuration["Infobip:InfobipTemplateURL"];
            var authorization = _configuration["Infobip:APIKey"];

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", authorization);

                    string payloadJson = JsonConvert.SerializeObject(outGoingTemplateMessageDTO);

                    var httpContent = new StringContent(payloadJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(BaseURL, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var myJsonResponse = await response.Content.ReadAsStringAsync();
                        return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    }
                    else
                    {
                        return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    }
                }
            }

            catch (Exception ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }



        public async Task<HttpResponseMessage> SendTextMessage(OutGoingMessageDto outGoingMessageDto1)
        {
            var BaseURL = _configuration["Infobip:InfobipBaseURL"] + _configuration["Infobip:InfobipTextURL"];
            var authorization = _configuration["Infobip:APIKey"];

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Add("Authorization", authorization);

                    string payloadJson = JsonConvert.SerializeObject(outGoingMessageDto1);
                    var httpContent = new StringContent(payloadJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(BaseURL, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Got Success Response");
                        var myJsonResponse = await response.Content.ReadAsStringAsync();
                        return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    }
                    else
                    {
                        return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    }
                }
            }

            catch (Exception ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }

}
