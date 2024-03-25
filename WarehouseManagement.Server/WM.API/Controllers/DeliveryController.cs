using Microsoft.AspNetCore.Mvc;
using WM.Entity.DTOs.DeliveryDTO;
using WM.Entity.DTOs.ProjectDTO;
using WM.Entity.Models;
using WM.Service;

namespace WM.API.Controllers
{
    [Route("api/delivery")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }
        [HttpGet("get-all-delivery")]
        public IActionResult GetAllDelivery()
        {
            var result = _deliveryService.GetAllDelivery();
            return Ok(result);
        }
/*        [HttpGet("get-delivery")]
        
        public IActionResult GetDeliveryByKeyword(int page, string? keyword = "")
        {
            var result = _deliveryService.GetDeliveryByKeyWord(page, keyword);
            return Ok(result);
        }*/

        [HttpGet("get-delivery")]      
        public IActionResult GetDeliveryById(int id)
        {
            var result = _deliveryService.GetDeliveryById(id);
            if (result == null)
            {
                return NotFound("Khong co ket qua");

            }
            else
                return Ok(result);
        }
        [HttpPost("add-delivery")]
        public async Task<IActionResult> AddDelivery(CreateDeliveryRequest delivery)
        {
            var result = _deliveryService.AddDelivery(delivery);
            return Ok(result);
        }

        [HttpPut("update-delivery")]
        public async Task<IActionResult> UpdateDelivery(UpdateDeliveryRequest delivery)
        {
            var result = _deliveryService.UpdateDelivery(delivery);
            return Ok(result);
        }
    }
}
