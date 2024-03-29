﻿using System;
using System.Collections.Generic;

namespace WM.Entity.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public int RoleId { get; set; }

    public int StatusId { get; set; }

    public string? UserName { get; set; }

    public int StorageId { get; set; }

    public string? UserCode { get; set; }

    public string? Address { get; set; }

    public string? Image { get; set; }

    public string? FullName { get; set; }

    public virtual ICollection<EmailToken> EmailTokens { get; } = new List<EmailToken>();

    public virtual ICollection<ExportOrder> ExportOrders { get; } = new List<ExportOrder>();

    public virtual ICollection<GoodsHistory> GoodsHistories { get; } = new List<GoodsHistory>();

    public virtual ICollection<ImportOrder> ImportOrders { get; } = new List<ImportOrder>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; } = new List<RefreshToken>();

    public virtual ICollection<ReturnsOrder> ReturnsOrders { get; } = new List<ReturnsOrder>();

    public virtual Role Role { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<StocktakeNote> StocktakeNoteCreatedNavigations { get; } = new List<StocktakeNote>();

    public virtual ICollection<StocktakeNote> StocktakeNoteUpdatedNavigations { get; } = new List<StocktakeNote>();

    public virtual Storage Storage { get; set; } = null!;
}
