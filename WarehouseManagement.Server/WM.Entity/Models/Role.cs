﻿using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();

    public virtual ICollection<Feature> Features { get; } = new List<Feature>();
}
