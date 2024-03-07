using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WM.Entity.DTOs.GoodsDTO;
using WM.Service;

namespace WM.API.Controllers
{
    [Route("api/goods")]
    [ApiController]

    public class GoodController : ControllerBase
    {
        private readonly IGoodsService _goodsService;

        public GoodController(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }
        // GET: GoodsController
        [HttpGet("get-all-goods")]
        public async Task <IActionResult> GetAllGoods()
        {
            var result = await _goodsService.GetAllGoods();
          
            return Ok(result);
        }

        [HttpGet("get-goods")]
        // GET: GoodsController/Details/5
        public IActionResult GetGoodsByKeyword(int offset, int limit, string? keyword = "")
        {
            var result = _goodsService.GetGoodsByKeyword(offset, limit, keyword);
            return Ok(result);
        }
        [HttpPost("add-goods")]
        public async Task<IActionResult> AddGoods(CreateGoodsRequest goods)
        {
            var result = _goodsService.AddGoods(goods);
            return Ok(result);
        }

        [HttpPut("update-goods")]
        public async Task<IActionResult> UpdateGoods(UpdateGoodsRequest goods)
        {
            var result = _goodsService.UpdateGoods(goods);
            return Ok(result);
        }

    }
}
