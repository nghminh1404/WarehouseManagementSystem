using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class ImportOrderDetail
{
    public int ImportId { get; set; }

    public float CostPrice { get; set; }

    public int DetailId { get; set; }

    public int? LoadsId { get; set; }

    public int? TotalAmount { get; set; }

    public string? Imagee { get; set; }

    public virtual ImportOrder Import { get; set; } = null!;
}
