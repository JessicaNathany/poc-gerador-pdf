using gerador_pdf.api.Model;
using gerador_pdf.api.Model.SGP;
using Microsoft.AspNetCore.Mvc;

namespace gerador_pdf.api.Service
{
    public interface IGeradorPdfServices
    {
        Task<FileStreamResult> GearPdf(PdfModel model);

        List<Pessoa> ObtendoArquivoJsonESerializandoEmUmObjeto();
    }
}
