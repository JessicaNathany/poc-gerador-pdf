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
            string caminhoArquivo = @"C:\Github\pessoas.json";

            var permissao = new FileIOPermission(FileIOPermissionAccess.Read, caminhoArquivo);
            permissao.Demand();

            // lendo conteúdo do arquivo json
            string jsonString = File.ReadAllText(caminhoArquivo);

            // Deserialize o arquivo json para dentro de uma classe c#
            var pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(jsonString);
            return pessoas;
        }

        public void CriarCelulaTexto(PdfCelulaTextoModel celulaTexto)
        {
            celulaTexto.TamanhoFonte = 12;
            celulaTexto.AlturaCelula = 25;

            int estilo = Font.NORMAL;

            if (celulaTexto.Negrito && celulaTexto.Italico)
            {
                estilo = Font.BOLDITALIC;
            }
            else if (celulaTexto.Negrito)
            {
                estilo = Font.BOLD;
            }
            else if (celulaTexto.Italico)
            {
                estilo = Font.ITALIC;
            }

            BaseFont fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            Font fonte = new Font(fonteBase, celulaTexto.TamanhoFonte, estilo, BaseColor.Black);

            //cor de fundo diferente para linhas pares e ímpares
            var bgColor = BaseColor.White;
           
            if (celulaTexto.Tabela.Rows.Count % 2 == 1)
            {
                bgColor = new BaseColor(0.95f, 0.95f, 0.95f);
            }

            PdfPCell celula = new PdfPCell(new Phrase(celulaTexto.Texto, fonte));
            celula.HorizontalAlignment = celulaTexto.Alinhamento;
            celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.PaddingBottom = 5; //pra alinhar melhor verticalmente
            celula.FixedHeight = celulaTexto.AlturaCelula;
            celula.BackgroundColor = bgColor;
            celulaTexto.Tabela.AddCell(celula);
        }
    }
}
