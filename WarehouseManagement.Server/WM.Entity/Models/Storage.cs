using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Storage
{
    public int StorageId { get; set; }

    public string StorageName { get; set; } = null!;

    public string? StorageAddress { get; set; }

    public string? StoragePhone { get; set; }

    public virtual ICollection<ExportOrder> ExportOrders { get; } = new List<ExportOrder>();

    public virtual ICollection<Good> Goods { get; } = new List<Good>();

    public virtual ICollection<ImportOrder> ImportOrders { get; } = new List<ImportOrder>();

    public virtual ICollection<Load> Loads { get; } = new List<Load>();

    public virtual ICollection<ReturnsOrder> ReturnsOrders { get; } = new List<ReturnsOrder>();

    public virtual ICollection<StocktakeNote> StocktakeNotes { get; } = new List<StocktakeNote>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
