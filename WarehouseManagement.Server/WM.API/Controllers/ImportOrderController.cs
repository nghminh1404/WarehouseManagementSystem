using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using WM.Entity.AutoMapper;
using WM.Entity.DTOs.ImportOrderDTO;
using WM.Entity.DTOs.UserDTO;
using WM.Entity.Models;
using WM.Service;

namespace WM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportOrderController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IImportOrderService _importService;
   
        private readonly WarehouseManagementContext _context;

        public ImportOrderController(IImportOrderService ImportOrderService, IConfiguration configuration, WarehouseManagementContext context)
        {
            _importService = ImportOrderService;
            _configuration = configuration;
            _context = context;
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
        //[HttpPost("add-import-order")]
        //public IActionResult AddImportOrder(CreateImportOrderRequest i)
        //{
        //    var result = _importService.CreateImportOrder(i);
        //    return Ok(result);
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("update-import-order")]
        //public IActionResult UpdateImportOrder(ImportOrderDTO i)
        //{
        //    var result = _importService.UpdateOrder(i);
        //    return Ok(result);
        //}
       
        [HttpPost("Import")]
        public async Task<IActionResult> Import(int importid)
        {
            try
            {
                var result = await _context.ImportOrders.Include(a => a.ImportOrderDetails).SingleOrDefaultAsync(x => x.ImportId == importid);
                if (result != null && result.StatusId == 1)
                {
                    result.StatusId = 4;
                    result.ImportedDate = DateTime.Now;
                    foreach (var detail in result.ImportOrderDetails)
                    {
                        var product = await _context.Goods.SingleOrDefaultAsync(x => x.GoodsId == detail.GoodsId);
                        ////var history = new ProductHistory
                        //{
                        //    ProductId = product.ProductId,
                        //    ActionId = 1
                        //};
                        int total = (int)detail.Quantity;
                        //if (detail.MeasuredUnitId != null)
                        //{
                        //    total = detail.Amount * detail.MeasuredUnit.MeasuredUnitValue;
                        product.InStock += total;
                        //}
                        //else
                        //{
                        //    total = detail.Amount;
                        //    history.AmountDifferential = $"+{detail.Amount}";
                        //    product.InStock += total;
                        //}
                        //history.AmountDifferential = $"+{total}";
                        //history.CostPrice = product.CostPrice;
                        //product.CostPrice = (detail.Amount * detail.CostPrice + product.InStock * product.CostPrice) / (total + product.InStock);
                        //var costdifferential = product.CostPrice - history.CostPrice;
                        //if (costdifferential > 0)
                        //    history.CostPriceDifferential = $"+{costdifferential}";
                        //else if (costdifferential < 0)
                        //    history.CostPriceDifferential = $"-{costdifferential}";
                        //else
                        //    history.CostPriceDifferential = null;
                        //history.ActionCode = result.ImportCode;
                        //history.UserId = result.UserId;
                        //history.Amount = product.InStock;
                        //history.Date = DateTime.Now;
                        //_context.Add(history);
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

