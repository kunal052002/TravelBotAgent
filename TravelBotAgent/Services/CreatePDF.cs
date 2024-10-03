using TravelBotAgent.Interface;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace TravelBotAgent.Services
{
    public class CreatePDF: ICreatePDF
    {
        public byte[] GeneratePDF(string userChoices)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document();
                PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                // Add content to the PDF
                document.Add(new Paragraph("User Selections:"));
                document.Add(new Paragraph(userChoices));

                document.Close();
                return memoryStream.ToArray();
            }
        }

        public void SavePDFLocally(byte[] pdfData, string filePath)
        {
            File.WriteAllBytes(filePath, pdfData);  // Save the PDF to a local file
        
        }
    }
}
