using Microsoft.AspNetCore.Mvc;
using WM.Entity.DTOs.ExportOrderDetailDTO;
using WM.Entity.DTOs.ImportOrderDetailDTO;
using WM.Service;

namespace WM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportOrderDetailController : ControllerBase
    {
        private readonly IExportOrderDetailService _orderDetailService;
        public ExportOrderDetailController(IExportOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        // GET: api/<ExportOrderDetailController>
        [HttpGet("get-all-export-details")]
        public IActionResult GetAllOrderDetails()
        {
            var order = _orderDetailService.GetAllExportOrderDetails();
            if (order == null)
            {
                return NotFound("Don't have order detail");
            }
            return Ok(order);

        }

        // GET api/<exportOrderDetailController>/5
        [HttpGet("get-iexport-order-details")]
        public IActionResult GetOrderDetailsByOrderID(int oid)
        {
            var order = _orderDetailService.GetOrderDetailsByOrderID(oid);
            if (order == null)
            {
                return NotFound("Don't have order detail");
            }
            return Ok(order);
        }
        // POST api/<ExportOrderDetailController>
        [HttpPost("add-order-detail")]
        public IActionResult AddOrderDetail([FromBody] CreateExportOrderDetailRequest detail)
        {
            var result = _orderDetailService.AddOrderDetail(detail);
            if (result == null)
            {
                return StatusCode(500);
            }
            return Ok(result);
        }

        // PUT api/<ExportOrderDetailController>/5
        [HttpPut("update-export-order-detail")]
        public IActionResult UpdateOrderDetail(UpdateExportOrderDetailRequest detail)
        {
            var result = _orderDetailService.UpdateOrderDetail(detail);
            if (result == null)
            {
                return StatusCode(500);
            }
            return Ok(result);
        }
        // DELETE api/<ExportOrderDetailController>/5
        [HttpDelete("delete-export-order-detail/{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            var result = _orderDetailService.DeleteExportOrderDetail(id);
            if (result == false)
            {
                return StatusCode(500);
            }
            return Ok("Delete order detail complete");
        }
    }
}
