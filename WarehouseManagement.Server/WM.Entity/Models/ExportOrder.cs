using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class ExportOrder
{
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

    public virtual ICollection<AvailableForReturn> AvailableForReturns { get; } = new List<AvailableForReturn>();

    public virtual Delivery? Delivery { get; set; }

    public virtual ICollection<ExportOrderDetail> ExportOrderDetails { get; } = new List<ExportOrderDetail>();

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<ReturnsOrder> ReturnsOrders { get; } = new List<ReturnsOrder>();

    public virtual Status Status { get; set; } = null!;

    public virtual Storage Storage { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
