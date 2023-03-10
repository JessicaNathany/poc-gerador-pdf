using gerador_pdf.api.Model;
using gerador_pdf.api.Model.SGP;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace gerador_pdf.api.Service
{
    public interface IGeradorPdfServices
    {
        Task<FileStreamResult> GearPdf(PdfModel model);

        List<Pessoa> ObtendoArquivoJsonESerializandoEmUmObjeto();

        //public void CriarCelulaTexto(PdfPTable tabela, string texto, int alinhamento = PdfPCell.ALIGN_LEFT, bool negrito = false, bool italico = false, int tamanhoFonte = 12, int alturaCelula = 25);
        void CriarCelulaTexto(PdfCelulaTextoModel celulaTexto);
    }
}
