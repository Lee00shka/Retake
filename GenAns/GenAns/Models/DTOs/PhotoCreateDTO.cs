using Microsoft.AspNetCore.Http;
namespace GenAns.Models.DTOs
{
    public class PhotoCreateDTO
    {
        public IFormFile photo { get; set; }
    }
}
