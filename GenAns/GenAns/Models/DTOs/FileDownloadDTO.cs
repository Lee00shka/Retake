namespace GenAns.Models.DTOs
{
    public class FileDownloadDTO
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
