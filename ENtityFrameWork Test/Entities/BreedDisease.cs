namespace ENtityFrameWork_Test.Entities
{
    public class BreedDisease
    {
        public int Id { get; set; }
        public int BreedId { get; set; }
        public int DiseaseId { get; set; }

        public virtual Breed Breed { get; set; }    
        public virtual Disease Disease { get; set; } 

    }
}
