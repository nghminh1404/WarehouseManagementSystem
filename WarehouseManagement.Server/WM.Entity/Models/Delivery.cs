using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Delivery
{
    public int DeliveyId { get; set; }

    public string? DeliveryName { get; set; }

    public virtual ICollection<ExportOrder> ExportOrders { get; } = new List<ExportOrder>();

    public virtual ICollection<ImportOrder> ImportOrders { get; } = new List<ImportOrder>();
}
