using iTextSharp.text.pdf;

namespace gerador_pdf.api.Model
{
    public class PdfCelulaTextoModel
    {
        public PdfPTable Tabela { get; set; }

        public string Texto { get; set; }

        public int Alinhamento { get; set; }

        public bool Negrito { get; set; }

        public bool Italico { get; set; }

        public int TamanhoFonte { get; set; }

        public int AlturaCelula { get; set; }
    }
}
