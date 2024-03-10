using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.DTOs;
using WM.Entity.DTOs.GoodsDTO;
using WM.Entity.DTOs.CategoryDTO;
using WM.Entity.Models;
using WM.Entity.DTOs.StorageDTO;

namespace WM.Service
{
    public interface ICategoryService
    {
        CategoryFilterPaging GetCategoryByKeyword(int page, string? keyword = "");
        Task<List<Category>?> GetAllCategory();
        Category? GetCategoryById(int id);
        CreateCategoryResponse AddCategory(CreateCategoryRequest category);
        UpdateCategoryResponse UpdateCaregory(UpdateCategoryRequest category);

    }

    public class CategoryService : ICategoryService
    {
        private readonly WarehouseManagementContext _context;
        public CategoryService(WarehouseManagementContext context)
        {
            _context = context;
        }

        public CreateCategoryResponse AddCategory(CreateCategoryRequest category)
        {
            try
            {
                var requestCategorry = new Category
                {
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
                _context.Categories.Add(requestCategorry);
                _context.SaveChanges();
                return new CreateCategoryResponse { IsSuccess = true, Message = $"Thêm loai hàng thành công" };
            }
            catch (Exception ex)
            {
                return new CreateCategoryResponse { IsSuccess = false, Message = $"Thêm loai hàng thất bại" };
            }
        }

        public async Task<List<Category>?> GetAllCategory()
        {
            try
            {
                var category = await _context.Categories.ToListAsync();
                return category;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Category GetCategoryById(int id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
                return category  ?? null;
            }catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CategoryFilterPaging? GetCategoryByKeyword(int page, string? keyword = "")
        {
            try
            {
                var pageSize = 6;

                var category = _context.Categories.Where(c => c.CategoryName.ToLower().Contains(keyword.ToLower())
                                                        || c.Description.ToLower().Contains(keyword.ToLower()))
                                                .OrderBy(c => c.CategoryId).ToList();
                var count = category.Count();
                var res = category.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var totalPages = Math.Ceiling((double)count / pageSize);
                return new CategoryFilterPaging { TotalPages = totalPages, PageSize = pageSize, category = res };

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /*public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest category)
        {
            try
            {
                var requestCategory = new Category { 
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
                _context.Categories.Update(requestCategory);
                _context.SaveChanges();
                return new UpdateCategoryResponse { IsSuccess = true, Message = "Update category successfully" };

            }
            catch (Exception e)
            {
                return new UpdateCategoryResponse { IsSuccess = false, Message = "Update category failed" };
            }
        }*/

        public UpdateCategoryResponse UpdateCaregory(UpdateCategoryRequest category)
        {
            try
            {
                var requestCategory = new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
                _context.Categories.Update(requestCategory);
                _context.SaveChanges();
                return new UpdateCategoryResponse { IsSuccess = true, Message = "Update category successfully" };

            }
            catch (Exception e)
            {
                return new UpdateCategoryResponse { IsSuccess = false, Message = "Update category failed" };
            }
        }
    }
}
