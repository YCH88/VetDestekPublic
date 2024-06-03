namespace ENtityFrameWork_Test.Entities
{
    public class AnimalDisease
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public int DiseaseId { get; set; }

        public virtual Animal Animal { get; set;}
        public virtual Disease Disease { get; set; }
    }
}
