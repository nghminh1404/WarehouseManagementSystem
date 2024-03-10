using Microsoft.AspNetCore.Mvc;
using WM.Service;

namespace WM.API.Controllers
{
    [Route("api/storage")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        // GET: StatusController
        [HttpGet("get-all-status")]
        public IActionResult GetAllStatus()
        {
            var result = _statusService.GetAllStatus();
            return Ok(result);
        }
    }
}
