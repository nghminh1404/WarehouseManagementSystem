using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("get-storage-by-keyword")]
        // GET: StorageController/Details/5
        public IActionResult GetStorageByKeyword(int offset,int limit, string keyword)
        {
            var result = _storageService.GetStoragesByKeyword(keyword,offset,limit);
            return Ok(result);
        }

        
    }
}
