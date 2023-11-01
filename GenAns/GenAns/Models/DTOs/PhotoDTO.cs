using Microsoft.Identity.Client;

namespace GenAns.Models.DTOs
{
    public class PhotoDTO
    {
        public Guid PhotoId { get; set; }
        public byte[] Content { get; set; }
        public SegmentationDTO Segmentation { get; set; }
    }
}
