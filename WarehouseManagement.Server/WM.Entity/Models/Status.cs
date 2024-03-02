using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusType { get; set; } = null!;

    public virtual ICollection<ExportOrder> ExportOrders { get; set; } = new List<ExportOrder>();

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();

    public virtual ICollection<ImportOrder> ImportOrders { get; set; } = new List<ImportOrder>();

    public virtual ICollection<Load> Loads { get; set; } = new List<Load>();

    public virtual ICollection<ReturnsOrder> ReturnsOrders { get; set; } = new List<ReturnsOrder>();

    public virtual ICollection<StocktakeNote> StocktakeNotes { get; set; } = new List<StocktakeNote>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
