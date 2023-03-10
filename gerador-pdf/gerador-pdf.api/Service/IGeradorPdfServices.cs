using gerador_pdf.api.Model;

namespace gerador_pdf.api.Service
{
    public interface IGeradorPdfServices
    {
        List<Pessoa> ObtendoArquivoJsonESerializandoEmUmObjeto();

        void CriarCelulaTexto(PdfCelulaTextoModel celulaTexto);
    }
}
