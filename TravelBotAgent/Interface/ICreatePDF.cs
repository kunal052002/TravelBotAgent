namespace TravelBotAgent.Interface
{
    public interface ICreatePDF
    {
        public byte[] GeneratePDF(string userChoices);
        public void SavePDFLocally(byte[] pdfData, string filePath);
    }
}
