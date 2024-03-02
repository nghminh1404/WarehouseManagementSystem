﻿using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class AvailableForReturn
{
    public int Id { get; set; }

    public int? ImportId { get; set; }

    public int? ExportId { get; set; }

    public int GoodsId { get; set; }

    public int Available { get; set; }

    public virtual ExportOrder? Export { get; set; }

    public virtual Good Goods { get; set; } = null!;

    public virtual ImportOrder? Import { get; set; }
}
