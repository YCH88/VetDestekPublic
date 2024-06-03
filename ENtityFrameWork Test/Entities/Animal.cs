namespace ENtityFrameWork_Test.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }
        public virtual ICollection<AnimalDisease> AnimalDisease { get; set; }
    }
}
