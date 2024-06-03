namespace ENtityFrameWork_Test.Entities
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual ICollection<BreedDisease> BreedDisease { get; set; }
    }
}
