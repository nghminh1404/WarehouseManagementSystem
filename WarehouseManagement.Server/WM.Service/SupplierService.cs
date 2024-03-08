using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.DTOs.SupplierDTO;
using WM.Entity.DTOs.StorageDTO;
using WM.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace WM.Service
{
    public interface ISupplierService
    {
        SupplierFilterPaging GetSupplierByKeyword(int page, string? keyword = "");
        Task <List<Supplier>?> GetAllSupplier();
        Supplier? GetSupplierById(int id);
        CreateSupplierResponse AddSupplier(CreateSupplierRequest supplier);
        UpdateSupplierResponse UpdateSupplier(UpdateSupplierRequest supplier);
        bool UpdateDeleteStatusUser(int id);
    }

    public class SupplierService : ISupplierService
    {
        private readonly WarehouseManagementContext _context;

        public SupplierService(WarehouseManagementContext context)
        {
            _context = context;
        }
        public CreateSupplierResponse AddSupplier(CreateSupplierRequest supplier)
        {
            try
            {
                var newSupplier = new Supplier
                {
                    SupplierName = supplier.SupplierName,
                    SupplierPhone = supplier.SupplierPhone,
                    StatusId = supplier.StatusId,
                    SupplierEmail = supplier.SupplierEmail,
                    Note = supplier.Note,
                };

                _context.Suppliers.Add(newSupplier);
                _context.SaveChanges();

                return new CreateSupplierResponse { IsSuccess = true, Message = "Supplier added successfully" };
            }
            catch (Exception ex)
            {
                return new CreateSupplierResponse { IsSuccess = false, Message = "Failed to add supplier" };
            }
        }

        public async Task<List<Supplier>?> GetAllSupplier()
        {
            try
            {
                return await _context.Suppliers.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Supplier? GetSupplierById(int id)
        {
            try
            {
                return _context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public SupplierFilterPaging? GetSupplierByKeyword(int page, string? keyword = "")
        {
            try
            {
                var pageSize = 6;

                var supplier = _context.Suppliers.Where(s => s.SupplierName.ToLower().Contains(keyword.ToLower()) ||
                                                        s.SupplierPhone.ToLower().Contains(keyword.ToLower()) ||
                                                        s.SupplierEmail.ToLower().Contains(keyword.ToLower()))
                                                .OrderBy(s => s.SupplierId).ToList();
                var count = supplier.Count();
                var res = supplier.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var totalPages = Math.Ceiling((double)count / pageSize);
                return new SupplierFilterPaging { TotalPages = totalPages, PageSize = pageSize, suppliers = res };

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateDeleteStatusUser(int id)
        {
            try
            {
                var user = GetSupplierById(id);
                if (user == null)
                {
                    return false;
                }
                else if (user.StatusId == 1)
                {
                    user.StatusId = 2;
                }
                else user.StatusId = 1;
                _context.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*public List<Supplier>? GetSupplierByKeyword(int offset, int limit, string? keyword = "")
        {
            try
            {
                var suppliers = _context.Suppliers
                    .Where(s => s.SupplierName.ToLower().Contains(keyword.ToLower()) ||
                                s.SupplierPhone.ToLower().Contains(keyword.ToLower()) ||
                                s.SupplierEmail.ToLower().Contains(keyword.ToLower()))
                    .OrderBy(s => s.SupplierId)
                    .ToList();

                var count = suppliers.Count();

                if (limit > count && offset >= 0)
                    return suppliers.Skip(offset).Take(count).ToList();
                else if (offset >= 0)
                    return suppliers.Skip(offset).Take(limit).ToList();
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/

        /*public SupplierFilterPaging? GetSupplieryKeyword(int page, string? keyword = "")
        {
            try
            {
                var pageSize = 6;

                var supplier = _context.Suppliers.Where(s => s.SupplierName.ToLower().Contains(keyword.ToLower()) ||
                                                        s.SupplierPhone.ToLower().Contains(keyword.ToLower()) ||
                                                        s.SupplierEmail.ToLower().Contains(keyword.ToLower()))
                                                .OrderBy(s => s.SupplierId).ToList();
                var count = supplier.Count();
                var res = supplier.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var totalPages = Math.Ceiling((double)count / pageSize);
                return new SupplierFilterPaging { TotalPages = totalPages, PageSize = pageSize, suppliers = res };

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/

        public UpdateSupplierResponse UpdateSupplier(UpdateSupplierRequest supplier)
        {
            try
            {
                var updatedSupplier = new Supplier
                {
                    SupplierId = supplier.SupplierId,
                    SupplierName = supplier.SupplierName,
                    SupplierPhone = supplier.SupplierPhone,
                    StatusId = supplier.StatusId,
                    SupplierEmail = supplier.SupplierEmail,
                    Note = supplier.Note,
                };

                _context.Suppliers.Update(updatedSupplier);
                _context.SaveChanges();

                return new UpdateSupplierResponse { IsSuccess = true, Message = "Supplier updated successfully" };
            }
            catch (Exception e)
            {
                return new UpdateSupplierResponse { IsSuccess = false, Message = "Failed to update supplier" };
            }
        }

        
    }
}
