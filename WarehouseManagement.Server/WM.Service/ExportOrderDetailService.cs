using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.DTOs.ExportOrderDetailDTO;
using WM.Entity.DTOs.ImportOrderDetailDTO;
using WM.Entity.Models;

namespace WM.Service
{
    public interface IExportOrderDetailService
    {
        List<ExportOrderDetail> GetAllExportOrderDetails();
        ExportOrderDetail? GetOrderDetailByOrderIdAndProductId(int oid, int pid);
        CreateExportOrderDetailResponse AddOrderDetail(CreateExportOrderDetailRequest detail);
        UpdateExportOrderDetailResponse UpdateOrderDetail(UpdateExportOrderDetailRequest detail);
        bool DeleteExportOrderDetail(int id);
        List<ExportOrderDetail> GetOrderDetailsProcessByCustomerId(int cid);
        List<ExportOrderDetail> GetOrderDetailsByOrderID(int oid);
    }
    public class ExportOrderDetailService : IExportOrderDetailService
    {
        private readonly WarehouseManagementContext _context;
        private readonly IExportOrderDetailService _orderService;
        public CreateExportOrderDetailResponse AddOrderDetail(CreateExportOrderDetailRequest detail)
        {
            try
            {
                var requestOrder = new ExportOrderDetail
                {
                    ExportId = detail.ExportId,
                    GoodsId = detail.GoodsId,
                    Quantity = detail.Quantity,
                    Price = detail.Price,
                };
                _context.ExportOrderDetails.Add(requestOrder);
                _context.SaveChanges();
                return new CreateExportOrderDetailResponse { IsSuccess = true, Message = "Add order detail complete" };
            }
            catch (Exception e)
            {
                return new CreateExportOrderDetailResponse { IsSuccess = false, Message = $"Add order detail failed {e.Message}" };

            }
        }

        public bool DeleteExportOrderDetail(int id)
        {
            try
            {
                var order = _context.ExportOrderDetails.SingleOrDefault(x => x.DetailId == id);
                _context.ExportOrderDetails.Remove(order);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ExportOrderDetail> GetAllExportOrderDetails()
        {
            try
            {
                var details = _context.ExportOrderDetails.ToList();
                return details;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ExportOrderDetail? GetOrderDetailByOrderIdAndProductId(int oid, int pid)
        {
            throw new NotImplementedException();
        }

        public List<ExportOrderDetail> GetOrderDetailsByOrderID(int oid)
        {
            try
            {
                var details = _context.ExportOrderDetails.Where(i => i.ExportId == oid)
                     .ToList();
                return details;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ExportOrderDetail> GetOrderDetailsProcessByCustomerId(int cid)
        {
            throw new NotImplementedException();
        }

        public UpdateExportOrderDetailResponse UpdateOrderDetail(UpdateExportOrderDetailRequest detail)
        {
            try
            {
                var requestOrder = new ExportOrderDetail
                {
                    DetailId = detail.DetailId,
                    ExportId = detail.ExportId,
                    GoodsId = detail.GoodsId,
                    Quantity = detail.Quantity,
                    Price = detail.Price
                };
                _context.Update(requestOrder);
                _context.SaveChanges();
                return new UpdateExportOrderDetailResponse { IsSuccess = true, Message = "Update order detail complete" };
            }
            catch (Exception e)
            {
                return new UpdateExportOrderDetailResponse { IsSuccess = false, Message = $"Update order detail failed {e.Message}" };
            }
        }
    }
}
