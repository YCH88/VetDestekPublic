namespace ENtityFrameWork_Test.Entities
{
    public class Disease
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Treatment { get; set; }
        public int? BreedId { get; set; }
        public bool IsForSpesificBreeds { get; set; }
        public virtual ICollection<DiseaseSymptom>  DiseaseSymptoms { get; set;}
        public virtual ICollection<AnimalDisease> AnimalDisease { get; set; }
        public virtual ICollection<BreedDisease> BreedDisease { get; set; }
    }
}
