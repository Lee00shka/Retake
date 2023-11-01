namespace GenAns.Models.DTOs
{
    public class CreateRockDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PercentageDTO> Specification { get; set; }
    }
}
