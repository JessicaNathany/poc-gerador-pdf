using gerador_pdf.api.Model;
using gerador_pdf.api.Model.SGP;
using gerador_pdf.api.Service;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using iTextSharp.LGPLv2.Core;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace gerador_pdf.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeradorPdfController : Controller
    {
        private readonly IGeradorPdfServices _geradorPdfServices;

        public GeradorPdfController(IGeradorPdfServices geradorPdfServices)
        {
            _geradorPdfServices = geradorPdfServices;
        }

        [HttpPost]
        [Route("gerador-pdf")]
        public async Task<ActionResult> GeraradorPDF([FromBody] PdfModel model)
        {
            throw new NotImplementedException();

            //MemoryStream memoryStream = new MemoryStream();

            //Document document = new Document(PageSize.A4, 36, 36, 36, 36);

            //PdfWriter.GetInstance(document, memoryStream).CloseStream = false;

            //document.Open();
            //document.Add(new Paragraph(model.Texto));

            //Font fonte = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.Black);

            //document.Close();

            ////C:\Github\gerador-pdf\gerador-pdf

            //byte[] byteInfo = memoryStream.ToArray();
            //memoryStream.Write(byteInfo, 0, byteInfo.Length);
            //memoryStream.Position = 0;

            //return new FileStreamResult(memoryStream, "application/pdf")
            //{
            //    FileDownloadName = $"{model.Roteiro}.pdf"
            //};
        }

        [HttpGet]
        public async Task<ActionResult> ExportarPdfPessoas()
        {
            var pessoas = _geradorPdfServices.ObtendoArquivoJsonESerializandoEmUmObjeto();
            var memoryStream = new MemoryStream();

            if(pessoas.Count == 0)
                return NoContent();

            //configurar dados para criar PDF
            var pixelsPorMilimetro = 72 / 25.2F;
            var pdf = new Document(PageSize.A4, 15 * pixelsPorMilimetro, 15 * pixelsPorMilimetro, 15 * pixelsPorMilimetro, 20 * pixelsPorMilimetro);

            var nomeArquivo = $"pessoas.{DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss")}.pdf";
            var arquivo = new FileStream(nomeArquivo, FileMode.Create);
            var pdfWriter = PdfWriter.GetInstance(pdf, arquivo);
            
            pdf.Open();

            var fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            var fonteParagrafo = new Font(fonteBase, 32, Font.NORMAL, BaseColor.Black);
            var titulo = new Paragraph("Relatório de Pessoas\n\n", fonteParagrafo);
            titulo.Alignment = Element.ALIGN_LEFT;
            pdf.Add(titulo);


            return new FileStreamResult(memoryStream, "application/pdf")
            {
                FileDownloadName = $"realtorio.pdf"
            };
        }
    }
}
