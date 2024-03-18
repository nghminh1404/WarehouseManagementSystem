using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.DTOs.ExportOrderDTO;
using WM.Entity.DTOs.ImportOrderDTO;
using WM.Entity.DTOs.UserDTO;
using WM.Entity.Models;

namespace WM.Service
{
    public interface IExportOrderService
    {
        UpdateExportOrderResponse UpdateOrder(ExportOrderDTO i);
        List<ExportOrderDTO> GetAllExportOrder();
        ExportOrder? GetExportOrderById(int id);
        ExportOrder? GetExportOrderByOrderCode(string code);
        CreateExportOrderResponse CreateExportOrder(CreateExportOrderRequest i);

        ExportOrderFilterPaging ExportOrderFilterPaging(int page, string? keyword, int? user = 0, int? storage = 0,
                                                        int? project = 0, int? storekeeper = 0,
                                                        int? status = 0);
    }
    public class ExportOrderService : IExportOrderService
    {
        private readonly WarehouseManagementContext _context;
        public ExportOrderService(WarehouseManagementContext context)
        {
            _context = context;
        }

        public CreateExportOrderResponse CreateExportOrder(CreateExportOrderRequest i)
        {
            try
            {
                var exportOrder = new ExportOrderDTO
                {
                    ExportCode = i.ExportCode,
                    UserId = i.UserId,
                    TotalPrice = i.TotalPrice,
                    Note = i.Note,
                    StatusId = i.StatusId,
                    CreatedDate = DateTime.Now,
                    ExportedDate = i.ExportedDate,
                    StorageId = i.StorageId,
                    ProjectId = i.ProjectId,
                    CancelDate = i.CancelDate,
                    DeliveryId = i.DeliveryId,
                    Image = i.Image,
                    StorekeeperId = i.StorekeeperId,
                    
                };
                _context.Add(exportOrder);
                _context.SaveChanges();
                return new CreateExportOrderResponse { IsSuccess = true, Message = "tao don hang xuat thanh cong" };

            }
            catch (Exception e) {
                return new CreateExportOrderResponse { IsSuccess = false, Message = $"Tao don hang xuat that bai +{e.Message}" };
            }
        }

        public ExportOrderFilterPaging ExportOrderFilterPaging(int page, string? keyword, int? user = 0, int? storage = 0, int? project = 0, int? storekeeper = 0, int? status = 0)
        {
            try
            {
                var pageSize = 10;
                if (page <= 0) page = 1;
                var users = _context.ExportOrders.Where(s => s.ExportCode.ToLower().Contains(keyword.ToLower())
                                                     
                                                      && (s.UserId == user || user == 0)
                                                      && (s.StorekeeperId == storekeeper || storekeeper == 0)
                                                      && (s.StatusId == status || status == 0)
                                                      && (s.StorageId == storage || storage == 0)
                                                      && (s.ProjectId == project || project == 0))
                                                .OrderBy(s => s.UserId).OrderBy(s => s.StatusId).ToList();
                var count = users.Count();
                var exportOrder = users.Select(i => new ExportOrderDTO
                {
                    ExportId = i.ExportId,
                    ExportCode = i.ExportCode,
                    UserId = i.UserId,
                    UserName = i.User.FullName,
                    TotalPrice = i.TotalPrice,
                    Note = i.Note,
                    StatusId = i.StatusId,
                    StatusType = i.Status.StatusType,
                    CreatedDate = i.CreatedDate,
                    ExportedDate = i.ExportedDate,
                    StorageId = i.StorageId,
                    StorageName = i.Storage.StorageName,
                    ProjectId = i.ProjectId,
                    ProjectName = i.Project.ProjectName,
                    CancelDate = i.CancelDate,
                    DeliveryId = i.DeliveryId,
                    DeliveryName = i.Delivery.DeliveryName,
                    Image = i.Image,
                    StorekeeperId = i.StorekeeperId,
                    StorekeeperName = i.User.FullName,
                    ExportOrderDetails = (List<ExportDetailDTO>)i.ExportOrderDetails
                    .Select(
                             i => new ExportDetailDTO
                             {
                                 ExportId = i.ExportId,
                                 Price = i.Price,
                                 GoodsId = i.GoodsId,
                                 Quantity = i.Quantity,
                             })
                });
                var res = exportOrder.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var totalPages = Math.Ceiling((double)count / pageSize);
                return new ExportOrderFilterPaging
                {
                    Data = res,                                            
                    PageSize = pageSize,
                    TotalPages = (int)totalPages
                };
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public List<ExportOrderDTO> GetAllExportOrder()
        {
            try
            {
                var exportOrder = _context.ExportOrders
                    // .Include(i => i.Status).Include(i => i.User).Include(i => i.Storage).Include(i => i.Storage).Include(i => i.Project)
                    .Select( i=> new ExportOrderDTO
                    {
                        ExportId = i.ExportId,
                        ExportCode = i.ExportCode,
                        UserId = i.UserId,
                        UserName = i.User.FullName,
                        TotalPrice = i.TotalPrice,
                        Note = i.Note,
                        StatusId = i.StatusId,
                        StatusType = i.Status.StatusType,
                        CreatedDate = i.CreatedDate,
                        ExportedDate = i.ExportedDate,
                        StorageId = i.StorageId,
                        StorageName = i.Storage.StorageName,
                        ProjectId = i.ProjectId,
                        ProjectName = i.Project.ProjectName,
                        CancelDate = i.CancelDate,
                        DeliveryId = i.DeliveryId,
                        DeliveryName = i.Delivery.DeliveryName,
                        Image = i.Image,
                        StorekeeperId = i.StorekeeperId,
                        StorekeeperName = i.User.FullName,
                        ExportOrderDetails = (List<ExportDetailDTO>)i.ExportOrderDetails.
                        Select(
                            i => new ExportDetailDTO
                            {
                                ExportId = i.ExportId,
                                GoodsId = i.GoodsId,
                                Price = i.Price,
                                Quantity = i.Quantity,
                            })                 
                    })
                    .ToList();
                return exportOrder;
            }catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ExportOrder? GetExportOrderById(int id)
        {
            try
            {
                var exportOrder = _context.ExportOrders
                    .Include(i => i.Status).Include(i => i.User).Include(i => i.Storage).Include(i => i.Storage).Include(i => i.Project)
                    .FirstOrDefault(i => i.ExportId == id);
                return exportOrder;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ExportOrder? GetExportOrderByOrderCode(string code)
        {
            try
            {
                var exportOrder = _context.ExportOrders
                    .Include(i => i.Status).Include(i => i.User).Include(i => i.Storage).Include(i => i.Storage).Include(i => i.Project)
                    .FirstOrDefault(i => i.ExportCode.ToLower().Contains(code.ToLower()));
                return exportOrder ?? null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public UpdateExportOrderResponse UpdateOrder(ExportOrderDTO i)
        {
            try
            {
                var exportOrder = new ExportOrderDTO
                {
                    ExportId = i.ExportId,
                    ExportCode = i.ExportCode,
                    UserId = i.UserId,
                    //UserName = i.User.FullName,
                    TotalPrice = i.TotalPrice,
                    Note = i.Note,
                    StatusId = i.StatusId,
                    // StatusType = i.Status.StatusType,
                    CreatedDate = i.CreatedDate,
                    ExportedDate = i.ExportedDate,
                    StorageId = i.StorageId,
                    // StorageName = i.Storage.StorageName,
                    ProjectId = i.ProjectId,
                    // ProjectName = i.Project.ProjectName,
                    CancelDate = i.CancelDate,
                    DeliveryId = i.DeliveryId,
                    //  DeliveryName = i.Delivery.DeliveryName,
                    Image = i.Image,
                    StorekeeperId = i.StorekeeperId,
                    // StorekeeperName = i.User.FullName,
                    ExportOrderDetails = (List<ExportDetailDTO>)i.ExportOrderDetails
                    .Select(
                            i => new ExportDetailDTO
                            {
                                ExportId = i.ExportId,
                                
                                Price = i.Price,
                                GoodsId = i.GoodsId,
                                Quantity = i.Quantity,
                            })
                };
                _context.Update(exportOrder);
                _context.SaveChanges();
                return new UpdateExportOrderResponse { IsSuccess = true, Message = "tao don hang nhap thanh cong" };

            }
            catch (Exception e)
            {
                return new UpdateExportOrderResponse { IsSuccess = false, Message = $"Tao don hang nhap that bai +{e.Message}" };
            }
        }
    }
}
