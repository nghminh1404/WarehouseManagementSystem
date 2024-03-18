﻿using Microsoft.AspNetCore.Mvc;
using WM.Entity.DTOs.ImportOrderDetailDTO;
using WM.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportOrderDetailController : ControllerBase
    {
        private readonly IImportOrderDetailService _orderDetailService;

        public ImportOrderDetailController(IImportOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        // GET: api/<ImportOrderDetailController>
        [HttpGet("get-all-import-details")]
        public IActionResult GetAllOrderDetails()
        {
            var order = _orderDetailService.GetAllOrderDetails();
            if (order == null)
            {
                return NotFound("Don't have order detail");
            }
            return Ok(order);

        }

        // GET api/<ImportOrderDetailController>/5
        [HttpGet("get-import-order-details")]
        public IActionResult GetOrderDetailsByOrderID(int oid)
        {
            var order = _orderDetailService.GetOrderDetailsByOrderID(oid);
            if (order == null)
            {
                return NotFound("Don't have order detail");
            }
            return Ok(order);
        }
        // POST api/<ImportOrderDetailController>
        [HttpPost("add-order-detail")]
        public IActionResult AddOrderDetail([FromBody] CreateImportOrderDetailRequest detail)
        {
            var result = _orderDetailService.AddOrderDetail(detail);
            if (result == null)
            {
                return StatusCode(500);
            }
            return Ok(result);
        }

        // PUT api/<ImportOrderDetailController>/5
        [HttpPut("update-import-order-detail")]
        public IActionResult UpdateOrderDetail(UpdateImportOrderDetailRequest detail)
        {
            var result = _orderDetailService.UpdateOrderDetail(detail);
            if (result == null)
            {
                return StatusCode(500);
            }
            return Ok(result);
        }
        // DELETE api/<ImportOrderDetailController>/5
        [HttpDelete("delete-import-order-detail/{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            var result = _orderDetailService.DeleteImportOrderDetail(id);
            if (result == false)
            {
                return StatusCode(500);
            }
            return Ok("Delete order detail complete");
        }
    }
}
