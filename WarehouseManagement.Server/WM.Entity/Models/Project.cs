using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public virtual ICollection<ExportOrder> ExportOrders { get; } = new List<ExportOrder>();

    public virtual ICollection<ImportOrder> ImportOrders { get; } = new List<ImportOrder>();
}
