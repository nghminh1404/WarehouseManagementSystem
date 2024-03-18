using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using WM.Entity.AutoMapper;
using WM.Entity.DTOs.ExportOrderDTO;
using WM.Entity.DTOs.UserDTO;
using WM.Entity.Models;
using WM.Service;

namespace WM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportOrderController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IExportOrderService _exportService;
        private readonly WarehouseManagementContext _context;

        public ExportOrderController(IExportOrderService exportOrderService, IConfiguration configuration, WarehouseManagementContext context)
        {
            _exportService = exportOrderService;           
            _configuration = configuration;
            _context = context;
        }
        [HttpGet("get-all-export-orders")]

        public IActionResult GetAllOrders() {
            var result = _exportService.GetAllExportOrder();
            return Ok(result);
        }

        [HttpGet("get-export-orders")]
        public IActionResult GetOrdersByKeyword(int page, string? keyword, int? user = 0, int? storage = 0,
                                                int? project = 0, int? storekeeper = 0, int? status = 0)
        {
            var reult = _exportService.ExportOrderFilterPaging(page, keyword, user, storage, project, storekeeper, status);
            return Ok(reult);
        }
        [HttpPost("add-export-order")]
        public IActionResult AddExportOrder(CreateExportOrderRequest i)
        {
            var result = _exportService.CreateExportOrder(i);
            return Ok(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("update-export-order")]
        public IActionResult UpdateExportOrder(ExportOrderDTO i)
        {
            var result = _exportService.UpdateOrder(i);
            return Ok(result);
        }
        [HttpPost("Export")]
        public async Task<IActionResult> Export(int exportid)
        {
            try
            {
                var result = await _context.ExportOrders.Include(a => a.ExportOrderDetails).SingleOrDefaultAsync(x => x.ExportId == exportid);
                if (result != null && result.StatusId == 1)
                {
                    result.StatusId = 4;
                    result.ExportedDate = DateTime.Now;
                    foreach (var detail in result.ExportOrderDetails)
                    {
                        var product = await _context.Goods.SingleOrDefaultAsync(x => x.GoodsId == detail.GoodsId);                       
                        int total = (int)detail.Quantity;                      
                        product.InStock += total;
                                          
                        _context.Goods.Update(product);
                    }
                    await _context.SaveChangesAsync();
                    return Ok("Thành công");
                }
                else
                {
                    return BadRequest("Không có dữ liệu");
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
