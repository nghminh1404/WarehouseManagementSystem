using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WM.Entity.DTOs.SupplierDTO;
using WM.Entity.DTOs.StorageDTO;
using WM.Service;
using WM.Entity.DTOs.GoodsDTO;

namespace WM.API.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: SupplierController
        [HttpGet("get-all-supplier")]
        public async Task<IActionResult> GetAllSupplier()
        {
            var result = await _supplierService.GetAllSupplier();        
            return Ok(result);
        }

        [HttpGet("get-supplier")]
        // GET: SupplierController/Details/5
        public IActionResult GetSupplierByKeyword(int page, string? keyword = "")
        {
            var result = _supplierService.GetSupplierByKeyword(page, keyword);
            return Ok(result);
        }
        [HttpPost("add-supplier")]
        public async Task<IActionResult> AddSupplier(CreateSupplierRequest supplier)
        {
            var result = _supplierService.AddSupplier(supplier);
            return Ok(result);
        }

        [HttpPut("update-supplier")]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierRequest supplier)
        {
            var result = _supplierService.UpdateSupplier(supplier);
            return Ok(result);
        }

    }
}
