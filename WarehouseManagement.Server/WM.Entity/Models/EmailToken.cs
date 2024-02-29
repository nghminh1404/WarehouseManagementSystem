using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class EmailToken
{
    public int TokenId { get; set; }

    public string Token { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime IssuedAt { get; set; }

    public DateTime ExpiredAt { get; set; }

    public bool IsUsed { get; set; }

    public bool IsRevoked { get; set; }

    public virtual User User { get; set; } = null!;
}
