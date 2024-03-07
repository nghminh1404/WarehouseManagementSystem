using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WM.Entity.Models;

public partial class Good
{
    public int GoodsId { get; set; }

    public string GoodsName { get; set; } = null!;

    public string? GoodsCode { get; set; }

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public int SupplierId { get; set; }

    public float CostPrice { get; set; }

    public string? DefaultMeasuredUnit { get; set; }

    public int InStock { get; set; }

    public string? Image { get; set; }

    public int? StatusId { get; set; }

    public float StockPrice { get; set; }
    [JsonIgnore]
    public DateTime WarrantyTime { get; set; }

    public string? Barcode { get; set; }

    public int StorageId { get; set; }

    public int? MaxStock { get; set; }

    public int? MinStock { get; set; }
    [JsonIgnore]
    public virtual ICollection<AvailableForReturn> AvailableForReturns { get; set; } = new List<AvailableForReturn>();
    [JsonIgnore]
    public virtual Category Category { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<GoodsHistory> GoodsHistories { get; set; } = new List<GoodsHistory>();
    [JsonIgnore]
    public virtual ICollection<MeasuredUnit> MeasuredUnits { get; set; } = new List<MeasuredUnit>();
    [JsonIgnore]
    public virtual ICollection<ReturnsOrderDetail> ReturnsOrderDetails { get; set; } = new List<ReturnsOrderDetail>();
    [JsonIgnore]
    public virtual Status? Status { get; set; }
    [JsonIgnore]
    public virtual ICollection<StocktakeNoteDetail> StocktakeNoteDetails { get; set; } = new List<StocktakeNoteDetail>();
    [JsonIgnore]
    public virtual Storage Storage { get; set; } = null!;
    [JsonIgnore]
    public virtual Supplier Supplier { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Load> Loads { get; set; } = new List<Load>();
}
