namespace GenAns.Data.Entity
{
    public class ProjectEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<PhotoEntity> Photos { get; set; }
        public SpecificationEntity Specification { get; set; }
    }
}
