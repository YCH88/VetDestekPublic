namespace ENtityFrameWork_Test.Entities
{
    public class Symptoms
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<DiseaseSymptom> DiseaseSymptom { get; set; }
    }
}
