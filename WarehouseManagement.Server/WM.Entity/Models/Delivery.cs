using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Delivery
{
    public int DeliveyId { get; set; }

    public string? DeliveryName { get; set; }

    public virtual ICollection<Load> Loads { get; } = new List<Load>();
}
