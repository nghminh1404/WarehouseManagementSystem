using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Load
{
    public int LoadsId { get; set; }

    public string LoadsCode { get; set; } = null!;

    public int GoodsId { get; set; }

    public int UserId { get; set; }

    public int SupplierId { get; set; }

    public int StorageId { get; set; }

    public string? Image { get; set; }

    public int StatusId { get; set; }

    public DateTime Created { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public int? DeliveryId { get; set; }

    public int? IsPaid { get; set; }

    public int Amount { get; set; }

    public virtual Delivery? Delivery { get; set; }

    public virtual Status Status { get; set; } = null!;
}
