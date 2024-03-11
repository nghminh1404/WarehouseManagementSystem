using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class ImportOrder
{
    public int ImportId { get; set; }

    public int UserId { get; set; }

    public int SupplierId { get; set; }

    public int TotalAmount { get; set; }

    public float Total { get; set; }

    public float TotalCost { get; set; }

    public string? Note { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Completed { get; set; }

    public int StatusId { get; set; }

    public string ImportCode { get; set; } = null!;

    public int StorageId { get; set; }

    public int ProjectId { get; set; }

    public virtual ICollection<AvailableForReturn> AvailableForReturns { get; } = new List<AvailableForReturn>();

    public virtual ICollection<ImportOrderDetail> ImportOrderDetails { get; } = new List<ImportOrderDetail>();

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<ReturnsOrder> ReturnsOrders { get; } = new List<ReturnsOrder>();

    public virtual Status Status { get; set; } = null!;

    public virtual Storage Storage { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
