using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class ImportOrderDetail
{
    public int ImportId { get; set; }

    public float CostPrice { get; set; }

    public int DetailId { get; set; }

    public int? GoodsId { get; set; }

    public int? Quantity { get; set; }

    public string? Image { get; set; }

    public virtual Good? Goods { get; set; }

    public virtual ImportOrder Import { get; set; } = null!;
}
