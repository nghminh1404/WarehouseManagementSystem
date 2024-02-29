using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class StocktakeNote
{
    public int StocktakeId { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Canceled { get; set; }

    public DateTime? Updated { get; set; }

    public int StatusId { get; set; }

    public int? UpdatedId { get; set; }

    public int StorageId { get; set; }

    public string? Note { get; set; }

    public int CreatedId { get; set; }

    public string StocktakeCode { get; set; } = null!;

    public virtual User CreatedNavigation { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<StocktakeNoteDetail> StocktakeNoteDetails { get; set; } = new List<StocktakeNoteDetail>();

    public virtual Storage Storage { get; set; } = null!;

    public virtual User? UpdatedNavigation { get; set; }
}
