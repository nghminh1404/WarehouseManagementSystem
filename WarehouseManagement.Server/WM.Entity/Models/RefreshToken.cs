using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class RefreshToken
{
    public int TokenId { get; set; }

    public int UserId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime ExpiredAt { get; set; }

    public bool? IsRevoked { get; set; }

    public string JwtId { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
