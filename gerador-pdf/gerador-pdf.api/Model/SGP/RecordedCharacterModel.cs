namespace gerador_pdf.api.Model.SGP
{
    public class RecordedCharacterModel
    {
        public string IdRoupaCenica { get; set; }
        public string CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string NomeTalento { get; set; }
        public string ArrivalTime { get; set; }
        public string Comment { get; set; }
        public List<string> Clothes { get; set; }
        public string CharacterSituation { get; set; }
        public string CharacterObsCharacterization { get; set; }
        public string CharacterClothesContinuityNote { get; set; }
        public string CharacterPlannedNote { get; set; }
        public string CharacterObs { get; set; }
        public string? PreviousSceneChapter { get; set; }
        public string? NextSceneChapter { get; set; }
        //public List<ClothingPicture> ClothingPictures { get; set; }
        //public List<ClothingHistoryItem> ClothingHistoryItems { get; set; }
        public string CharacterObsEcont { get; set; }
    }
}
