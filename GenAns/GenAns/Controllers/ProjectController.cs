using GenAns.Models.DTOs;
using GenAns.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenAns.Controllers
{
    [ApiController]
    [Route("api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("{projectid}/photo")]
        public ActionResult<List<ShortPhotoDTO>> GetPhotos(Guid projectId)
        {
            return Ok(new List<ShortPhotoDTO>() );
        }

        [HttpGet]
        [Route("{projectid}/photo/{photoId}")]
        public ActionResult<PhotoDTO> GetPhotoById(Guid projectId, Guid photoId)
        {
            return Ok(new PhotoDTO());
        }

        [HttpPost]
        [Route("{projectid}/photo/add")]
        public void AddPhoto(Guid projectId, PhotoCreateDTO photoInfo)
        {

        }

        [HttpDelete]
        [Route("{projectid}/photo/{photoId}")]
        public void DeletePhotoByid(Guid projectId, Guid photoId)
        {

        }

        //Запросы по проекту

        [HttpGet]
        public ActionResult<List<ShortProjectDTO>> GetProjects()
        {
            return Ok(new List<ShortProjectDTO>());
        }

        [HttpGet]
        [Route("{projectId}")]
        public ActionResult<ProjectDTO> GetProjectById()
        {
            return Ok(new ProjectDTO());
        }

        [HttpPost]
        [Route("create")]
        public void CreateProject(CreateProjectDTO projectInfo)
        {

        }
        [HttpDelete]
        [Route("{projectId}/delete")]
        public void DeleteProject(Guid projectId) 
        { 

        }
    }
}
