using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.DTOs;
using WM.Entity.DTOs.StorageDTO;
using WM.Entity.Models;

namespace WM.Service
{
    public interface IStorageService
    {
        StorageFilterPaging GetStoragesByKeyword(int page, string? keyword = "");
        List<Storage>? GetAllStorage();
        Storage? GetStorageById(int id);
        CreateStorageResponse AddStorage(CreateStorageRequest storage);
        UpdateStorageResponse UpdateStorage(UpdateStorageRequest storage);
    }
    public class StorageService : IStorageService
    {
        private readonly WarehouseManagementContext _context;

        public StorageService(WarehouseManagementContext context)
        {
            _context = context;
        }

        public CreateStorageResponse AddStorage(CreateStorageRequest storage)
        {
            try
            {
                var requestStorage = new Storage
                {
                    StorageName = storage.StorageName,
                    StorageAddress = storage.StorageAddress
                };
                _context.Storages.Add(requestStorage);
                _context.SaveChanges();
                return new CreateStorageResponse { IsSuccess = true, Message = $"Thêm kho hàng thành công" };
            }
            catch (Exception ex)
            {
                return new CreateStorageResponse { IsSuccess = false, Message = $"Thêm kho hàng thất bại" };
            }
        }

        public List<Storage>? GetAllStorage()
        {
            try
            {
                var storages = _context.Storages.ToList();
                return storages;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Storage? GetStorageById(int id)
        {
            try
            {
                var storages = _context.Storages.FirstOrDefault(s => s.StorageId == id);
                return storages ?? null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //offset: chỉ vị trí bắt đầu của bản ghi
        //limit: số lượng bản ghi được phép hiển thị
        //keyword: search string
        // Dùng để phân trang, search,filter, get all data
        //public List<Storage>? GetStoragesByKeyword(int offset, int limit, string? keyword = "")
        //{
        //    try
        //    {

        //        var storages = _context.Storages.Where(s => s.StorageName.ToLower().Contains(keyword.ToLower())
        //                                                || s.StorageAddress.ToLower().Contains(keyword.ToLower()))
        //                                        .OrderBy(s => s.StorageId).ToList();
        //        var count = storages.Count();
        //        if (limit > count && offset >= 0)
        //        {
        //             return storages.Skip(offset).Take(count).ToList();

        //        }

        //        else if (offset >= 0)
        //        {
        //            return storages.Skip(offset).Take(limit).ToList();  
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //        }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public StorageFilterPaging? GetStoragesByKeyword(int page, string? keyword = "")
        {
            try
            {
                var pageSize = 6;

                var storages = _context.Storages.Where(s => s.StorageName.ToLower().Contains(keyword.ToLower())
                                                        || s.StorageAddress.ToLower().Contains(keyword.ToLower()))
                                                .OrderBy(s => s.StorageId).ToList();
                var count = storages.Count();
                var res = storages.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var totalPages = Math.Ceiling((double)count / pageSize);
                return new StorageFilterPaging { TotalPages = totalPages, PageSize = pageSize, storages = res };

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public UpdateStorageResponse UpdateStorage(UpdateStorageRequest storage)
        {
            try
            {
                var requestStorage = new Storage
                {
                    StorageId = storage.StorageId,
                    StorageName = storage.StorageName,
                    StorageAddress = storage.StorageAddress
                };
                _context.Storages.Update(requestStorage);
                _context.SaveChanges();
                return new UpdateStorageResponse { IsSuccess = true, Message = "Update storage successfully" };

            }
            catch (Exception e)
            {
                return new UpdateStorageResponse { IsSuccess = false, Message = "Update storage failed" };
            }
        }
    }
}
