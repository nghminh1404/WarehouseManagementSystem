using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WM.Entity.DTOs.StorageDTO;
using WM.Service;

namespace WM.API.Controllers
{
    [Route("api/storage")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }
        // GET: StorageController
        [HttpGet("get-all-storage")]
        public IActionResult GetAllStorage()
        {
            var result = _storageService.GetAllStorage();
            return Ok(result);
        }

        [HttpGet("get-storage")]
        // GET: StorageController/Details/5
        public IActionResult GetStorageByKeyword(int page, string? keyword ="")
        {
            var result = _storageService.GetStoragesByKeyword(page, keyword);
            return Ok(result);
        }
        [HttpPost("add-storage")]
        public async Task<IActionResult> AddStorage(CreateStorageRequest storage)
        {
            var result = _storageService.AddStorage(storage);
            return Ok(result);
        }

        [HttpPut("update-storage")]
        public async Task<IActionResult> UpdateStorage(UpdateStorageRequest storage )
        {
            var result = _storageService.UpdateStorage(storage);
            return Ok(result);
        }
    }
}
