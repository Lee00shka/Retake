namespace GenAns.Data.Entity
{
    public class SpecificationEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
