namespace GenAns.Models.DTOs
{
    public class SegmentationDTO
    {
        public Guid PhotoID { get; set; }
        public List<SegmentDTO> Segments { get; set; }
    }
}
