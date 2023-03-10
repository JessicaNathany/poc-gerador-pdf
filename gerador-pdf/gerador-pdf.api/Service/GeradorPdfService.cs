using gerador_pdf.api.Model;
using gerador_pdf.api.Model.SGP;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Security.Permissions;

namespace gerador_pdf.api.Service
{

    public class GeradorPdfService : IGeradorPdfServices
    {
        public async Task<FileStreamResult> GearPdf(PdfModel model)
        {
            MemoryStream memoryStream = new MemoryStream();

            Document document = new Document(PageSize.A4, 36, 36, 36, 36);

            //PdfWriter.GetInstance(document, memoryStream).CloseStream = false;
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("output.pdf", FileMode.Create));

            document.Open();
            document.Add(new Paragraph(model.Texto));
            Font fonte = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.Black);


            document.Close();

            byte[] byteInfo = memoryStream.ToArray();
            memoryStream.Write(byteInfo, 0, byteInfo.Length);
            memoryStream.Position = 0;


            return new FileStreamResult(memoryStream, "application/pdf")
            {
                FileDownloadName = "arquivo.pdf"
            };
        }

        public List<Pessoa> ObtendoArquivoJsonESerializandoEmUmObjeto()
        {
            string filePath = @"C:\Github\pessoas.json";

            FileIOPermission permissao = new FileIOPermission(FileIOPermissionAccess.Read, filePath);
            permissao.Demand();

            // lendo conteúdo do arquivo json
            string jsonString = File.ReadAllText(filePath);

            // Deserialize o arquivo json para dentro de uma classe c#
            List<Pessoa> pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(jsonString);

            return pessoas;
        }
    }
}
