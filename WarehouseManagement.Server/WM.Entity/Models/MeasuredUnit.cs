using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class MeasuredUnit
{
    public int MeasuredUnitId { get; set; }

    public int GoodsId { get; set; }

    public string MeasuredUnitName { get; set; } = null!;

    public int MeasuredUnitValue { get; set; }

    public float? SuggestedPrice { get; set; }

    public virtual Good Goods { get; set; } = null!;

    public virtual ICollection<ReturnsOrderDetail> ReturnsOrderDetails { get; } = new List<ReturnsOrderDetail>();
}
