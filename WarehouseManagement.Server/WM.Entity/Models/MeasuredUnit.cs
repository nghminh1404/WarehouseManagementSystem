using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class MeasuredUnit
{
    public int MeasuredUnitId { get; set; }

    public string MeasuredUnitName { get; set; } = null!;

    public int MeasuredUnitValue { get; set; }
}
