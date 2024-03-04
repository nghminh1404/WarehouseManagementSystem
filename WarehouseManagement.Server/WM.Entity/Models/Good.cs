using System;
using System.Collections.Generic;

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

    public DateTime WarrantyTime { get; set; }

    public string? Barcode { get; set; }

    public int StorageId { get; set; }

    public int? MaxStock { get; set; }

    public int? MinStock { get; set; }

    public virtual ICollection<AvailableForReturn> AvailableForReturns { get; set; } = new List<AvailableForReturn>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<GoodsHistory> GoodsHistories { get; set; } = new List<GoodsHistory>();

    public virtual ICollection<MeasuredUnit> MeasuredUnits { get; set; } = new List<MeasuredUnit>();

    public virtual ICollection<ReturnsOrderDetail> ReturnsOrderDetails { get; set; } = new List<ReturnsOrderDetail>();

    public virtual Status? Status { get; set; }

    public virtual ICollection<StocktakeNoteDetail> StocktakeNoteDetails { get; set; } = new List<StocktakeNoteDetail>();

    public virtual Storage Storage { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual ICollection<Load> Loads { get; set; } = new List<Load>();
}
