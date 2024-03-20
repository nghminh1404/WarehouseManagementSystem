using Microsoft.AspNetCore.Mvc;
using WM.Entity.DTOs.ProjectDTO;
using WM.Entity.DTOs.StorageDTO;
using WM.Service;

namespace WM.API.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        // GET: ProjectController
        [HttpGet("get-all-project")]
        public IActionResult GetAllProject()
        {
            var result = _projectService.GetAllProject();
            return Ok(result);
        }

        [HttpGet("get-project")]
        public IActionResult GetProjectById(int id)
        {
            var result = _projectService.GetProjectById(id);
            if (result == null)
            {
                return NotFound("Khong co ket qua");

            }
            else
                return Ok(result);
        }
        [HttpPost("add-project")]
        public async Task<IActionResult> AddProject(CreateProjectRequest project)
        {
            var result = _projectService.AddProject(project);
            return Ok(result);
        }

        [HttpPut("update-project")]
        public async Task<IActionResult> UpdateProject(UpdateProjectRequest project)
        {
            var result = _projectService.UpdateProject(project);
            return Ok(result);
        }
    }
}
