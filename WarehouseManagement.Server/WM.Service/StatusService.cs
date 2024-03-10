using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.DTOs;

using WM.Entity.Models;

namespace WM.Service
{
    public interface IStatusService
    {
        List<Status> GetAllStatus();
    }
    public class StatusService : IStatusService
    {
        private readonly WarehouseManagementContext _context;

        public StatusService(WarehouseManagementContext context)
        {
            _context = context;
        }
        public List<Status> GetAllStatus()
        {
            try
            {
                var status = _context.Statuses.ToList();
                return status;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
