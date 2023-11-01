using GenAns.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GenAns.Controllers
{
    [ApiController]
    [Route("api/segmentation")]
    public class SegmentationController : ControllerBase
    {
        [HttpPut]
        [Route("set")]
        public void SetSegmentation(SegmentationDTO segmentation)
        {

        }
    }
}
