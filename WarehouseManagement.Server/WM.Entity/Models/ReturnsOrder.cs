﻿using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class ReturnsOrder
{
    public int ReturnsId { get; set; }

    public int? ImportId { get; set; }

    public int? ExportId { get; set; }

    public int? SupplierId { get; set; }

    public int UserId { get; set; }

    public string? Note { get; set; }

    public string? Image { get; set; }

    public DateTime Created { get; set; }

    public string ReturnsCode { get; set; } = null!;

    public int StorageId { get; set; }

    public float Total { get; set; }

    public int State { get; set; }

    public DateTime? Imported { get; set; }

    public virtual ExportOrder? Export { get; set; }

    public virtual ImportOrder? Import { get; set; }

    public virtual ICollection<ReturnsOrderDetail> ReturnsOrderDetails { get; } = new List<ReturnsOrderDetail>();

    public virtual Status StateNavigation { get; set; } = null!;

    public virtual Storage Storage { get; set; } = null!;

    public virtual Supplier? Supplier { get; set; }

    public virtual User User { get; set; } = null!;
}
