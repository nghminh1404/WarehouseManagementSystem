using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class Feature
{
    public int FeatureId { get; set; }

    public string Featurename { get; set; } = null!;

    public string? Url { get; set; }

    public virtual ICollection<Role> Roles { get; } = new List<Role>();
}
