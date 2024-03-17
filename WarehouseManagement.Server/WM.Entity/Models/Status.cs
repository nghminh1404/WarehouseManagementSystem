using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusType { get; set; } = null!;

    public virtual ICollection<ExportOrder> ExportOrders { get; } = new List<ExportOrder>();

    public virtual ICollection<Good> Goods { get; } = new List<Good>();

    public virtual ICollection<ImportOrder> ImportOrders { get; } = new List<ImportOrder>();

    public virtual ICollection<ReturnsOrder> ReturnsOrders { get; } = new List<ReturnsOrder>();

    public virtual ICollection<StocktakeNote> StocktakeNotes { get; } = new List<StocktakeNote>();

    public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
