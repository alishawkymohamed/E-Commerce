using IHelperServices;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Options;
using Models.DTOs;
using System.IO;

namespace HelperServices
{
    public class PrintServices : _HelperService, IPrintServices
    {
        private readonly AppSettings _AppSettings;
        private readonly string _RootPath;
        public PrintServices(IOptions<AppSettings> appSettings)
        {
            _AppSettings = appSettings.Value;
            _RootPath = _AppSettings.FileSettings.RelativeDirectory;
        }

        public byte[] ExportPDF(string html)
        {
            StringReader stringReader = new StringReader(html);

            Document pdfDoc = new Document(PageSize.A4);

            HtmlWorker htmlparser = new HtmlWorker(pdfDoc);

            MemoryStream memoryStream = new MemoryStream();

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

            pdfDoc.Open();

            htmlparser.Parse(stringReader);

            pdfDoc.Close();

            byte[] bytes = memoryStream.ToArray();

            memoryStream.Close();

            return bytes != null ? bytes : new byte[] { };

        }

    }

}
