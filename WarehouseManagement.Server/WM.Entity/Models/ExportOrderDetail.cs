using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class ExportOrderDetail
{
    public int DetailId { get; set; }

    public int ExportId { get; set; }

    public float Price { get; set; }

    public int? LoadsId { get; set; }

    public int? TotalAmount { get; set; }

    public string? Image { get; set; }

    public virtual ExportOrder Export { get; set; } = null!;
}
