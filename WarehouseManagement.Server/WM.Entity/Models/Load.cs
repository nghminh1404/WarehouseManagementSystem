using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Load
{
    public int LoadsId { get; set; }

    public string LoadsCode { get; set; } = null!;

    public int UserId { get; set; }

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

    public virtual Storage Storage { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Good> Goods { get; } = new List<Good>();
}
