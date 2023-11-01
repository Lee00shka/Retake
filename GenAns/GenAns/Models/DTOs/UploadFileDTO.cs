namespace GenAns.Models.DTOs
{
    public class UploadFileDTO
    {
        public string BucketName { get; set; }
        public IFormFile File { get; set; }
    }
}
