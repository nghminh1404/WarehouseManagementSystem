﻿using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
}
