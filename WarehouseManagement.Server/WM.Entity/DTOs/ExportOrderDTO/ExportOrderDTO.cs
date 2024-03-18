using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs.ExportOrderDTO
{
    public class ExportOrderDTO
    {
        public string? UserName;

        public string StatusType;
        public string? StorekeeperName;
        public string StorageName;
        public string ProjectName;
        public string? DeliveryName;

        public int ExportId { get; set; }

        public string ExportCode { get; set; } = null!;

        public int UserId { get; set; }

        public float TotalPrice { get; set; }

        public string? Note { get; set; }

        public int StatusId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ExportedDate { get; set; }

        public int StorageId { get; set; }

        public int ProjectId { get; set; }

        public DateTime? CancelDate { get; set; }

        public int? DeliveryId { get; set; }

        public string? Image { get; set; }

        public int? StorekeeperId { get; set; }

        public List<ExportDetailDTO> ExportOrderDetails { get; set; }
    }
}
