namespace GenAns.Models.DTOs
{
    public class RockDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PercentageDTO Percentage { get; set; }
    }
}
