namespace ENtityFrameWork_Test.Models.Home
{
    public class DiseaseListDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Treatment { get; set; }
        public string Symptoms { get; set; }
        public List<int> SymptomId { get; set; }
        public string Animals { get; set; }
        public int TotalRecord { get; set; }
    }
}
