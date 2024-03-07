﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.DTOs;
using WM.Entity.DTOs.GoodsDTO;
using WM.Entity.DTOs.StorageDTO;
using WM.Entity.Models;

namespace WM.Service
{
    public interface IGoodsService
    {
        GoodsFilterPaging GetGoodsByKeyword(int page, string? keyword = "");
       Task <List<Good>?> GetAllGoods();
        Good GetGoodsById(int id);
        CreateGoodsResponse AddGoods(CreateGoodsRequest goods);
        UpdateGoodsResponse UpdateGoods(UpdateGoodsRequest goods);
    }
    public class GoodsService : IGoodsService
    {
        private readonly WarehouseManagementContext _context;
        public GoodsService(WarehouseManagementContext context)
        {
            _context = context;
        }

        public CreateGoodsResponse AddGoods(CreateGoodsRequest goods)
        {
            try
            {
                var requestGoods = new Good
                {
                    GoodsName = goods.GoodsName,
                    GoodsCode = goods.GoodsCode,
                    CategoryId = goods.CategoryId,
                    Description = goods.Description,
                    SupplierId = goods.SupplierId,
                    CostPrice = goods.CostPrice,
                    DefaultMeasuredUnit = goods.DefaultMeasuredUnit,
                    InStock = goods.InStock,
                    Image = goods.Image,
                    StatusId = goods.StatusId,
                    StockPrice = goods.StockPrice,
                    WarrantyTime = DateTime.Now,
                    Barcode = goods.Barcode,
                    StorageId = goods.StorageId,
                    MaxStock = goods.MaxStock,
                    MinStock = goods.MinStock
                    
                };
                _context.Goods.Add(requestGoods);
                _context.SaveChanges();
                return new CreateGoodsResponse { IsSuccess = true, Message = $"Thêm hang hoa thành công" };
            }
            catch (Exception ex)
            {
                return new CreateGoodsResponse { IsSuccess = false, Message = $"Thêm hàng hoa thất bại" };
            }
        }

        public async Task<List<Good>?> GetAllGoods()
        {
            try
            {
                var goods = await _context.Goods.ToListAsync();
                return goods;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Good GetGoodsById(int id)
        {
            try
            {
                var goods = _context.Goods.FirstOrDefault(g => g.GoodsId == id);
                return goods ?? null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /*public List<Good>? GetGoodsByKeyword(int offset, int limit, string? keyword = "")
        {
            try
            {

                var goods = _context.Goods.Where(g => g.GoodsName.ToLower().Contains(keyword.ToLower())
                                                        || g.GoodsCode.ToLower().Contains(keyword.ToLower())
                                                        )
                                                .OrderBy(g => g.GoodsId).ToList();
                var count = goods.Count();
                if (limit > count && offset >= 0)
                {
                    return goods.Skip(offset).Take(count).ToList();

                }

                else if (offset >= 0)
                {
                    return goods.Skip(offset).Take(limit).ToList();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/

        public GoodsFilterPaging? GetGoodsByKeyword(int page, string? keyword = "")
        {
            try
            {
                var pageSize = 6;

                var goods = _context.Goods.Where(g => g.GoodsName.ToLower().Contains(keyword.ToLower())
                                                        || g.GoodsCode.ToLower().Contains(keyword.ToLower()))
                                                .OrderBy(g => g.GoodsId).ToList();
                var count = goods.Count();
                var res = goods.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var totalPages = Math.Ceiling((double)count / pageSize);
                return new GoodsFilterPaging { TotalPages = totalPages, PageSize = pageSize, goods = res };

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public UpdateGoodsResponse UpdateGoods(UpdateGoodsRequest goods)
        {
            try
            {
                var requestGoods = new Good

                {
                    GoodsName = goods.GoodsName,
                    GoodsCode = goods.GoodsCode,
                    CategoryId = goods.CategoryId,
                    Description = goods.Description,
                    SupplierId = goods.SupplierId,
                    CostPrice = goods.CostPrice,
                    DefaultMeasuredUnit = goods.DefaultMeasuredUnit,
                    InStock = goods.InStock,
                    Image = goods.Image,
                    StatusId = goods.StatusId,
                    StockPrice = goods.StockPrice,
                    WarrantyTime = DateTime.Now,
                    Barcode = goods.Barcode,
                    StorageId = goods.StorageId,
                    MaxStock = goods.MaxStock,
                    MinStock = goods.MinStock
                };
                _context.Goods.Update(requestGoods);
                _context.SaveChanges();
                return new UpdateGoodsResponse { IsSuccess = true, Message = $"Cập nhật hàng hóa thành công" };

            }
            catch (Exception ex)
            {
                return new UpdateGoodsResponse { IsSuccess = false, Message = $"Cập nhật hàng hóa thất bại" };
            }
        }

        
    }
}
