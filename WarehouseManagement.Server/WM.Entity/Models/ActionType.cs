using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class ActionType
{
    public int ActionId { get; set; }

    public string Action { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<GoodsHistory> GoodsHistories { get; } = new List<GoodsHistory>();
}
