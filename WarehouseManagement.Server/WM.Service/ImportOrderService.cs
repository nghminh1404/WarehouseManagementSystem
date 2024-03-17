using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.DTOs.ImportOrderDTO;
using WM.Entity.DTOs.UserDTO;
using WM.Entity.Models;

namespace WM.Service
{
    public interface IImportOrderService
    {
        UpdateImportOrderResponse UpdateOrder(ImportOrderDTO i);
        List<ImportOrderDTO> GetAllImportOrder();
        ImportOrder? GetImportOrderById(int id);
        ImportOrder? GetImportOrderByOrderCode(string code);

        CreateImportOrderResponse CreateImportOrder(CreateImportOrderRequest i);
        ImportOrderFilterPaging ImportOrderFilterPaging(int page, string? keyword, int? user = 0, int? storage = 0,
                                                        int? project = 0,  int? storekeeper = 0,
                                                        int? status = 0);
    }

    public class ImportOrderService : IImportOrderService
    {
        private readonly WarehouseManagementContext _context;

        public ImportOrderService(WarehouseManagementContext context)
        {
            _context = context;
        }
        public CreateImportOrderResponse CreateImportOrder(CreateImportOrderRequest i)
        {
            try
            {
                var importOrder = new ImportOrderDTO
                {
                    ImportCode = i.ImportCode,
                    UserId = i.UserId,
                    //  UserName = i.User.FullName,
                    SupplierId = i.SupplierId,
                    //  SupplierName = i.Supplier.SupplierName,
                    TotalCost = i.TotalCost,
                    Note = i.Note,
                    CreatedDate = i.CreatedDate,
                    ImportedDate = i.ImportedDate,
                    StatusId = i.StatusId,
                    // StatusType = i.Status.StatusType,
                    StorageId = i.StorageId,
                    // StorageName = i.Storage.StorageName,
                    ProjectId = i.ProjectId,
                    // ProjectName = i.Project.ProjectName,
                    DeliveryId = i.DeliveryId,
                    //  DeliveryName = i.Delivery.DeliveryName,
                    Image = i.Image,
                    StorekeeperId = i.StorekeeperId,
                    // StorekeeperName = i.User.FullName,
                    ImportOrderDetails = (List<ImportDetailDTO>)i.ImportOrderDetails
                        .Select(
                                i => new ImportDetailDTO
                                {
                                    ImportId = i.ImportId,
                                    DetailId = i.DetailId,
                                    CostPrice = i.CostPrice,
                                    GoodsId = i.GoodsId,
                                    // GoodsName = i.Goods.GoodsName,
                                    Quantity = i.Quantity,
                                    // MeasureUnit = i.Goods.MeasuredUnit
                                })
                    };
                _context.Add(importOrder);
                _context.SaveChanges();
                return new CreateImportOrderResponse { IsSuccess = true, Message = "Tao don hang nhap vao thanh cong"};
            }
            catch (Exception e)
            {
                return new CreateImportOrderResponse { IsSuccess = false, Message = $"Tao don hang that bai +{e.Message }" };
            }
        }

        public List<ImportOrderDTO> GetAllImportOrder()
        {
            try
            {
                var importOrder = _context.ImportOrders
                    .Include(i => i.Status).Include(i => i.User).Include(i => i.Storage).Include(i => i.Storage).Include(i=> i.Project)
                    .Select( i=> new ImportOrderDTO
                    {
                        ImportId = i.ImportId,
                        ImportCode = i.ImportCode,
                        UserId = i.UserId,
                        UserName = i.User.FullName,
                        SupplierId = i.SupplierId,
                        SupplierName = i.Supplier.SupplierName,
                        TotalCost = i.TotalCost,
                        Note = i.Note,
                        CreatedDate = i.CreatedDate,
                        ImportedDate = i.ImportedDate,
                        StatusId = i.StatusId,
                        StatusType = i.Status.StatusType,
                        StorageId = i.StorageId,
                        StorageName = i.Storage.StorageName,
                        ProjectId = i.ProjectId,
                        ProjectName = i.Project.ProjectName,
                        DeliveryId = i.DeliveryId,
                        DeliveryName = i.Delivery.DeliveryName,
                        Image = i.Image,
                        StorekeeperId = i.StokekeeperId,
                        StorekeeperName = i.User.FullName,
                        ImportOrderDetails = (List<ImportDetailDTO>)i.ImportOrderDetails
                        .Select(
                                i => new ImportDetailDTO {
                                ImportId = i.ImportId,
                                DetailId = i.DetailId,
                                CostPrice = i.CostPrice,
                                GoodsId = i.GoodsId,
                                GoodsName = i.Goods.GoodsName,
                                Quantity = i.Quantity,
                                MeasureUnit = i.Goods.MeasuredUnit
                                })
                    })
                    .ToList();
                return importOrder;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); 
            }
        }

        public ImportOrder? GetImportOrderById(int id)
        {
            try
            {
                var importOrder = _context.ImportOrders
                    .Include(i => i.Status).Include(i => i.User).Include(i => i.Storage).Include(i => i.Storage).Include(i => i.Project)
                    .FirstOrDefault(i => i.ImportId == id);                  
                return importOrder;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ImportOrder? GetImportOrderByOrderCode(string code)
        {
            try
            {
                var importOrder = _context.ImportOrders
                    .Include(i => i.Status).Include(i => i.User).Include(i => i.Storage).Include(i => i.Storage).Include(i => i.Project)
                    .FirstOrDefault(i => i.ImportCode.ToLower().Contains(code.ToLower()));
                return importOrder ?? null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ImportOrderFilterPaging ImportOrderFilterPaging(int page, string? keyword, int? user = 0, int? storage = 0,
                                                        int? project = 0, int? storekeeper = 0, int? status = 0)
        {
            try
            {
                var pageSize = 10;
                if (page <= 0) page = 1;
                var users = _context.ImportOrders.Where(s => s.ImportCode.ToLower().Contains(keyword.ToLower())
                                                      || s.Supplier.SupplierName.ToLower().Contains(keyword.ToLower())                                                    
                                                      && (s.UserId == user || user == 0)
                                                      && (s.StokekeeperId == storekeeper || storekeeper == 0)
                                                      && (s.StatusId == status|| status == 0)
                                                      && (s.StorageId == storage || storage == 0)
                                                      && (s.ProjectId ==project || project == 0))
                                                .OrderBy(s => s.UserId).OrderBy(s => s.StatusId).ToList();
                var count = users.Count();
                var res = users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var totalPages = Math.Ceiling((double)count / pageSize);
                return new ImportOrderFilterPaging
                {
                    Data = ((List<ImportOrderDTO>)(from i in res
                                         select new ImportOrderDTO
                                         {
                                             ImportId = i.ImportId,
                                             ImportCode = i.ImportCode,
                                             UserId = i.UserId,
                                             UserName = i.User.FullName,
                                             SupplierId = i.SupplierId,
                                             SupplierName = i.Supplier.SupplierName,
                                             TotalCost = i.TotalCost,
                                             Note = i.Note,
                                             CreatedDate = i.CreatedDate,
                                             ImportedDate = i.ImportedDate,
                                             StatusId = i.StatusId,
                                             StatusType = i.Status.StatusType,
                                             StorageId = i.StorageId,
                                             StorageName = i.Storage.StorageName,
                                             ProjectId = i.ProjectId,
                                             ProjectName = i.Project.ProjectName,
                                             DeliveryId = i.DeliveryId,
                                             DeliveryName = i.Delivery.DeliveryName,
                                             Image = i.Image,
                                             StorekeeperId = i.StokekeeperId,
                                             StorekeeperName = i.User.FullName,
                                             ImportOrderDetails = (List<ImportDetailDTO>)i.ImportOrderDetails
                        .Select(
                                i => new ImportDetailDTO
                                {
                                    ImportId = i.ImportId,
                                    DetailId = i.DetailId,
                                    CostPrice = i.CostPrice,
                                    GoodsId = i.GoodsId,
                                    GoodsName = i.Goods.GoodsName,
                                    Quantity = i.Quantity,
                                    MeasureUnit = i.Goods.MeasuredUnit
                                })                                      
                                         })),
                    PageSize = pageSize,
                    TotalPages = (int)totalPages
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public UpdateImportOrderResponse UpdateOrder(ImportOrderDTO i)
        {
            try
            {


                var importOrder = new ImportOrderDTO
                {
                    ImportId = i.ImportId,
                    ImportCode = i.ImportCode,
                    UserId = i.UserId,
                    //  UserName = i.User.FullName,
                    SupplierId = i.SupplierId,
                    //  SupplierName = i.Supplier.SupplierName,
                    TotalCost = i.TotalCost,
                    Note = i.Note,
                    CreatedDate = i.CreatedDate,
                    ImportedDate = i.ImportedDate,
                    StatusId = i.StatusId,
                    // StatusType = i.Status.StatusType,
                    StorageId = i.StorageId,
                    // StorageName = i.Storage.StorageName,
                    ProjectId = i.ProjectId,
                    // ProjectName = i.Project.ProjectName,
                    DeliveryId = i.DeliveryId,
                    //  DeliveryName = i.Delivery.DeliveryName,
                    Image = i.Image,
                    StorekeeperId = i.StorekeeperId,
                    // StorekeeperName = i.User.FullName,
                    ImportOrderDetails = (List<ImportDetailDTO>)i.ImportOrderDetails
                            .Select(
                                    i => new ImportDetailDTO
                                    {
                                        ImportId = i.ImportId,
                                        DetailId = i.DetailId,
                                        CostPrice = i.CostPrice,
                                        GoodsId = i.GoodsId,
                                        // GoodsName = i.Goods.GoodsName,
                                        Quantity = i.Quantity,
                                        // MeasureUnit = i.Goods.MeasuredUnit
                                    })
                };
                _context.Update(importOrder);
                _context.SaveChanges();
                return new UpdateImportOrderResponse { IsSuccess = true, Message = "Cap nhap don hang nhap vao thanh cong" };
            }
            catch (Exception e)
            {
                return new UpdateImportOrderResponse { IsSuccess = false, Message = $"Cap nhap don hang that bai +{e.Message}" };
            }
        }
    }
}
