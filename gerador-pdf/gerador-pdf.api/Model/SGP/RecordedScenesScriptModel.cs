namespace gerador_pdf.api.Model.SGP
{
    public class ScriptSceneModel
    {
        public string SceneId { get; set; }
        public string ScriptNumber { get; set; }
        public string ScriptStatus { get; set; }
        public string ScriptDate { get; set; }
        public string ScriptDateDayOfWeek { get; set; }
        public string ScripVersion { get; set; }
        public string ReleaseDate { get; set; }
        public string ScriptFrontDirector { get; set; }
        public string ScriptLocation { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StartMeal { get; set; }
        public string EndRecord { get; set; }
        public string ScriptLength { get; set; }
        public string ObservacaoRoteiro { get; set; }
        public string RecadoGerente { get; set; }

        //public LocalGravacaoRoteiroViewModel LocalGravacaoRoteiro { get; set; }

        //public IEnumerable<SceneModel> Scenes { get; set; }
        //public IEnumerable<RecordedCharactersScriptViewModel> Characters { get; set; }
        //public IEnumerable<RecordedStuntScriptModel> Stunts { get; set; }
        //public IEnumerable<RecordedExtraScriptViewModel> Extras { get; set; }

    }
}
