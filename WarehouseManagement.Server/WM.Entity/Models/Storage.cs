using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace WM.Entity.Models;

public  class Storage
{
    public int StorageId { get; set; }

    public string StorageName { get; set; } = null!;

    public string? StorageAddress { get; set; }
    [JsonIgnore]

    public virtual ICollection<ExportOrder> ExportOrders { get; set; } = new List<ExportOrder>();
    [JsonIgnore]

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
    [JsonIgnore]

    public virtual ICollection<ImportOrder> ImportOrders { get; set; } = new List<ImportOrder>();
    [JsonIgnore]

    public virtual ICollection<Load> Loads { get; set; } = new List<Load>();
    [JsonIgnore]

    public virtual ICollection<ReturnsOrder> ReturnsOrders { get; set; } = new List<ReturnsOrder>();
    [JsonIgnore]

    public virtual ICollection<StocktakeNote> StocktakeNotes { get; set; } = new List<StocktakeNote>();
    [JsonIgnore]

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    [JsonIgnore]

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
