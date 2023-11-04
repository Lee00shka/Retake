namespace GenAns.Data.Entity
{
    public class PhotoEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public SpecificationEntity Specification { get; set; }
    }
}
