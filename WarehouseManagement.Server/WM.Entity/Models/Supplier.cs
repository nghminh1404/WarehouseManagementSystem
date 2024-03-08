using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string SupplierPhone { get; set; } = null!;

    public int StatusId { get; set; }

    public string? SupplierEmail { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<Good> Goods { get; } = new List<Good>();

    public virtual ICollection<ImportOrder> ImportOrders { get; } = new List<ImportOrder>();

    public virtual ICollection<ReturnsOrder> ReturnsOrders { get; } = new List<ReturnsOrder>();

    public virtual Status Status { get; set; } = null!;
}
