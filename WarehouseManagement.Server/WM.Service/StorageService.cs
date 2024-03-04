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
        List<Storage>? GetStoragesByKeyword(string keyword, int offset, int limit);
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
                return storages ?? null ;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Storage>? GetStoragesByKeyword(string keyword, int offset, int limit)
        {
            try
            {
                var storages = _context.Storages.Where(s => s.StorageName.ToLower().Contains(keyword.ToLower())
                                                        || s.StorageAddress.ToLower().Contains(keyword.ToLower()))
                                                .OrderByDescending(s => s.StorageId).ToList();
                var count = storages.Count();
                if (limit > count && offset >= 0)
                {
                     return storages.Skip(offset).Take(count).ToList();
                   
                }

                else if (offset >= 0)
                {
                    return storages.Skip(offset).Take(limit).ToList();
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
        }

        public UpdateStorageResponse UpdateStorage(UpdateStorageRequest storage)
        {
            throw new NotImplementedException();
        }
    }
}
