using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class StocktakeNoteDetail
{
    public int DetailId { get; set; }

    public int StocktakeId { get; set; }

    public int GoodsId { get; set; }

    public int CurrentStock { get; set; }

    public int ActualStock { get; set; }

    public int AmountDifferential { get; set; }

    public string? Note { get; set; }

    public virtual Good Goods { get; set; } = null!;

    public virtual StocktakeNote Stocktake { get; set; } = null!;
}
