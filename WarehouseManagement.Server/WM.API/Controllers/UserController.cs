using Microsoft.AspNetCore.Mvc;
using WM.Entity.DTOs.UserDTO;
using WM.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet("get-all-user")]
        public IActionResult GetAllUser()
        {
            var result = _userService.GetAllUser();
            return Ok(result);
        }

        [HttpGet("get-users")]
        public IActionResult GetUserByKeyword(int pageNum, string? keyword="", int? role = 0, int? statusId = 0, int? storageId = 0) 
        {
        var reult = _userService.GetUsersByKeyword(pageNum,keyword,role,statusId,storageId);
        return Ok(reult);
        }

        // GET api/<UserController>/5
        [HttpGet("get-user-by-id")]
        public IActionResult GetUserById(int id)
        {
            var result  = _userService.GetUserById(id);
            if(result == null)
            {
                return NotFound("Khong co ket qua");

            }
            else
                    return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost("add-user")]
        public IActionResult AddUser(CreateUserRequest user )
        {
            var result = _userService.AddUser(user);
            return Ok(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("update-user")]
        public IActionResult UpdateUser(UpdateUserRequest user)
        {
            var result = _userService.UpdateUser(user);
            return Ok(result);
        }

        
        [HttpPut("update-user-status")]
        public async Task<IActionResult> UpdateStatus(int id)
        {
            var user = _userService.UpdateDeleteStatusUser(id);
            return Ok(user);
        }
    }
}
