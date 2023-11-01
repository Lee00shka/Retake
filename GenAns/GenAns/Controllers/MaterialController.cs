using GenAns.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GenAns.Controllers
{
    [ApiController]
    [Route("api/material")]
    public class MaterialController: ControllerBase
    {
        [HttpGet]
        [Route("mineral")]
        public ActionResult<List<ShortMaterialDTO>> GetMinerals()
        {
            return Ok(new List<ShortMaterialDTO>());
        }

        [HttpGet]
        [Route("rock")]
        public ActionResult<List<ShortMaterialDTO>> GetRock()
        {
            return Ok(new List<ShortMaterialDTO>());
        }

        [HttpGet]
        [Route("mineral/{id}")]
        public ActionResult<MineralDTO> GetMineralById()
        {
            return Ok(new MineralDTO());
        }

        [HttpGet]
        [Route("rock/{id}")]
        public ActionResult<RockDTO> GetRockById()
        {
            return Ok(new RockDTO());
        }

        [HttpPost]
        [Route("mineral/create")]
        public void CreateMineral(CreateMineralDTO mineralInfo)
        {

        }

        [HttpPost]
        [Route("rock/create")]
        public void CreateRock(CreateRockDTO rockInfo)
        {

        }

        [HttpDelete]
        [Route("mineral/{id}")]
        public void DeleteMineral(Guid id)
        {

        }
        [HttpDelete]
        [Route("rock/{id}")]
        public void DeleteRock(Guid id)
        {

        }
    }
}
