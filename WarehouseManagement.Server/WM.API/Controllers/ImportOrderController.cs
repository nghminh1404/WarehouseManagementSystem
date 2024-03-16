using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using WM.Entity.DTOs.ImportOrderDTO;
using WM.Entity.DTOs.UserDTO;
using WM.Service;

namespace WM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportOrderController : ControllerBase
    {
        private readonly IImportOrderService _importService;

        public ImportOrderController(IImportOrderService ImportOrderService  )
        {
            _importService = ImportOrderService;
        }
        [HttpGet("get-all-import-orders")]
        public IActionResult GetAllOrders()
        {
            var result = _importService.GetAllImportOrder();
            return Ok(result);
        }

        [HttpGet("get-import-orders")]
        public IActionResult GetOrdersByKeyword(int page, string? keyword, int? user = 0, int? storage = 0,
                                                int? project = 0, int? storekeeper = 0, int? status = 0)
        {
            var reult = _importService.ImportOrderFilterPaging(page,keyword,user,storage,project,storekeeper,status);
            return Ok(reult);
        }
        [HttpPost("add-import-order")]
        public IActionResult AddImportOrder(CreateImportOrderRequest i)
        {
            var result = _importService.CreateImportOrder(i);
            return Ok(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("update-import-order")]
        public IActionResult UpdateImportOrder(ImportOrderDTO i)
        {
            var result = _importService.UpdateOrder(i);
            return Ok(result);
        }
      
    }
}
