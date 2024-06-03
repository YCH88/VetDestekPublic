namespace ENtityFrameWork_Test.Entities
{
    public class DiseaseSymptom
    {
        public int Id { get; set; }
        public int DiseaseId { get; set; }
        public int SymptomId { get; set; }

        public virtual Disease Disease { get; set; }
        public virtual Symptoms Symptoms { get; set; }
    }
}
