namespace gerador_pdf.api.Model
{
    [Serializable]
    public class RoteiroGravaoPdf
    {
        public string LiberadoEm { get; set; }
        public string Local { get; set; }
        public string Direcao { get; set; }
        public string DiretorDeFrente { get; set; }
        public string Observacao { get; set; }
        public string TotalPagina { get; set; }
        public string Exibindo { get; set; }
        public string Roteiros { get; set; }
        public string Versao { get; set; }
        public string DataGravacao { get; set; }
        public string HoraSaida { get; set; }
        public string HoraInicio { get; set; }
        public string HoraRefeicao { get; set; }
        public string HoraFim { get; set; }
        public string Personagem { get; set; }
        public string NomeArtistico { get; set; }
        public string HoraChegada { get; set; }
        public string Comentario { get; set; }
        public string Figurantes { get; set; }
        public string Dubles { get; set; }
    }
}
