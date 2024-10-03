using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TravelBotAgent.DTOs;
using TravelBotAgent.Interface;
using TravelBotAgent.Services;

namespace TravelBotAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelBotController : Controller
    {
        private readonly IProcessingIncomingMessage _processingIncomingMessage;
        private readonly ICreatePDF _createPDF;
        public TravelBotController(IProcessingIncomingMessage processingIncomingMessage, ICreatePDF createPDF)
        {
            _processingIncomingMessage = processingIncomingMessage;
            _createPDF = createPDF;
        }
        [HttpPost("InboundMessage")]
        public async Task<IActionResult> InboundMessage([FromBody] Object jsonMessage)
        {

            string jsonString = jsonMessage.ToString();
            IncomingMessageDto incomingMessageDto = JsonConvert.DeserializeObject<IncomingMessageDto>(jsonString);

            await _processingIncomingMessage.CreateMessage(incomingMessageDto);

            return Ok();
        }
    }
}

        //        [HttpGet("Test")]
        //        public async Task Test()
        //        {
        //            string pdf_data = "Day 1: Arrival in Goa, check into a beach resort, relax on the beach.\r\n    Day 2: North Goa sightseeing – Visit Baga Beach, Anjuna Beach, and Fort Aguada.             Day 3: South Goa tour – Colva Beach, Dudhsagar Waterfalls, Basilica of Bom Jesus.\r\n Day 4: Water sports – Parasailing, Jet skiing, and Scuba diving.\r\n Day 5: Leisure time, shopping, and departure.";
        //            byte[] pdf = _createPDF.GeneratePDF(pdf_data);

        //            var folder = "Doc/";
        //            var pdfName = Guid.NewGuid().ToString() + ".pdf";
        //            var pdfPath = folder + pdfName;
        //            _createPDF.SavePDFLocally(pdf, pdfPath);


        //            var pdfURL = "https://p0c51xdw-7099.inc1.devtunnels.ms/" + pdfPath;

        //            var authorization = "App 58de9a30379c220c848bc6fb5a03701a-b2b29bbd-3f28-40a1-aa23-1e1b70ba1cca";
        //            using HttpClient client = new();
        //            client.BaseAddress = new Uri("https://kjq93.api.infobip.com");
        //            client.DefaultRequestHeaders.Clear();
        //            client.DefaultRequestHeaders.Add("Authorization", authorization);
        //            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            string SENDER = "27872405259";
        //            string RECIPIENT = "918390508064";

        //            //var strJson = $@"{{""messages"":[{{""from"":""{SENDER}"",""to"":""{RECIPIENT}"",""messageId"":""1234"",""content"":{{""templateName"":""tb_hotel_location"",""templateData"":{{""body"":{{""placeholders"":[]}},""buttons"":[{{""type"": ""URL"",""parameter"": ""/""}}]}},""language"":""en""}},""callbackData"":""Callback data"",""notifyUrl"":""""}}]}}";
        //            //var strJson = $@"{{""messages"":[{{""from"":""27872405259"",""to"":""918390508064"",""messageId"":""2033caf8-3bbb-44bc-9ba7-b47bee43628b"",""content"":{{""templateName"":""tb_hotel_location"",""templateData"":{{""body"":{{""placeholders"":[]}},""buttons"":null,""header"":{{""type"":""LOCATION"",""mediaUrl"":null,""latitude"":12.974444072304298,""longitude"":77.61806539611719}}}},""language"":""en""}},""callbackData"":""Callback Data"",""notifyUrl"":"""",""urlOptions"":null}}]}}";
        //            var strJson = $@"{{
        //  ""messages"": [
        //    {{
        //      ""from"": ""27872405259"",
        //      ""to"": ""918390508064"",
        //      ""messageId"": ""a28dd97c-1ffb-4fcf-99f1-0b557ed381da"",
        //      ""content"": {{
        //        ""templateName"": ""tb_pdf"",
        //        ""templateData"": {{
        //          ""body"": {{
        //            ""placeholders"": []
        //          }},
        //          ""header"": {{
        //            ""type"": ""DOCUMENT"",
        //            ""mediaUrl"": ""{pdfPath}"",
        //            ""filename"": ""{pdfName}""
        //          }}
        //        }},
        //        ""language"": ""en""
        //      }},
        //      ""callbackData"": ""Callback data"",
        //      ""notifyUrl"": ""https://www.example.com/whatsapp"",
        //      ""urlOptions"": {{
        //        ""shortenUrl"": true,
        //        ""trackClicks"": true,
        //        ""trackingUrl"": ""https://example.com/click-report"",
        //        ""removeProtocol"": true,
        //        ""customDomain"": ""example.com""
        //      }}
        //    }}
        //  ]
        //}}";
        //            var messageType = "/whatsapp/1/message/template";

        //            //var url = _configuration.GetRequiredSection("RedirectButtonParameter");

        //            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, messageType);
        //            httpRequest.Content = new StringContent(strJson, Encoding.UTF8, "application/json");

        //            var result = await client.SendAsync(httpRequest);
        //            var responseContent = await result.Content.ReadAsStringAsync();


        //        }
        //    }
    
