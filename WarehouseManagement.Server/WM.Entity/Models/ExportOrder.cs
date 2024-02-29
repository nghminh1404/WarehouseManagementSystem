using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class ExportOrder
{
    public int ExportId { get; set; }

    public string ExportCode { get; set; } = null!;

    public int UserId { get; set; }

    public int TotalAmount { get; set; }

    public float Total { get; set; }

    public float TotalPrice { get; set; }

    public string? Note { get; set; }

    public int StatusId { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Completed { get; set; }

    public int StorageId { get; set; }

    public int ProjectId { get; set; }

    public DateTime? Denied { get; set; }

    public virtual ICollection<AvailableForReturn> AvailableForReturns { get; set; } = new List<AvailableForReturn>();

    public virtual ICollection<ExportOrderDetail> ExportOrderDetails { get; set; } = new List<ExportOrderDetail>();

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<ReturnsOrder> ReturnsOrders { get; set; } = new List<ReturnsOrder>();

    public virtual Status Status { get; set; } = null!;

    public virtual Storage Storage { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
