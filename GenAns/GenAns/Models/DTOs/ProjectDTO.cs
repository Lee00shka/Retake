namespace GenAns.Models.DTOs
{
    public class ProjectDTO
    {
        public Guid ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public List<ShortPhotoDTO> Photos { get; set; }
    }
}
