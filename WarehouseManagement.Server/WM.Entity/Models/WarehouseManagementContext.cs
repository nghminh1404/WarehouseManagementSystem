using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WM.Entity.Models;

public partial class WarehouseManagementContext : DbContext
{
    public WarehouseManagementContext()
    {
    }

    public WarehouseManagementContext(DbContextOptions<WarehouseManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActionType> ActionTypes { get; set; }

    public virtual DbSet<AvailableForReturn> AvailableForReturns { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<EmailToken> EmailTokens { get; set; }

    public virtual DbSet<ExportOrder> ExportOrders { get; set; }

    public virtual DbSet<ExportOrderDetail> ExportOrderDetails { get; set; }

    public virtual DbSet<Feature> Features { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<GoodsHistory> GoodsHistories { get; set; }

    public virtual DbSet<ImportOrder> ImportOrders { get; set; }

    public virtual DbSet<ImportOrderDetail> ImportOrderDetails { get; set; }

    public virtual DbSet<MeasuredUnit> MeasuredUnits { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<ReturnsOrder> ReturnsOrders { get; set; }

    public virtual DbSet<ReturnsOrderDetail> ReturnsOrderDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StocktakeNote> StocktakeNotes { get; set; }

    public virtual DbSet<StocktakeNoteDetail> StocktakeNoteDetails { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {
        var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("SqlConnection");
        optionsBuilder.UseSqlServer("server = DESKTOP-IPI496K; database = WarehouseManagement; uid=sa; pwd=123; TrustServerCertificate=True");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActionType>(entity =>
        {
            entity.HasKey(e => e.ActionId);

            entity.ToTable("ActionType");

            entity.Property(e => e.ActionId).ValueGeneratedNever();
            entity.Property(e => e.Action).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(250);
        });

        modelBuilder.Entity<AvailableForReturn>(entity =>
        {
            entity.HasOne(d => d.Export).WithMany(p => p.AvailableForReturns).HasForeignKey(d => d.ExportId);

            entity.HasOne(d => d.Goods).WithMany(p => p.AvailableForReturns)
                .HasForeignKey(d => d.GoodsId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Import).WithMany(p => p.AvailableForReturns).HasForeignKey(d => d.ImportId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(250);
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveyId);

            entity.ToTable("Delivery");

            entity.Property(e => e.DeliveryName).HasMaxLength(50);
        });

        modelBuilder.Entity<EmailToken>(entity =>
        {
            entity.HasKey(e => e.TokenId);

            entity.ToTable("EmailToken");

            entity.Property(e => e.Token).HasMaxLength(64);

            entity.HasOne(d => d.User).WithMany(p => p.EmailTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ExportOrder>(entity =>
        {
            entity.HasKey(e => e.ExportId);

            entity.ToTable("ExportOrder");

            entity.Property(e => e.ExportCode).HasMaxLength(50);
            entity.Property(e => e.Image)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Note).HasMaxLength(250);

            entity.HasOne(d => d.Delivery).WithMany(p => p.ExportOrders)
                .HasForeignKey(d => d.DeliveryId)
                .HasConstraintName("FK_ExportOrder_Delivery");

            entity.HasOne(d => d.Project).WithMany(p => p.ExportOrders)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExportOrder_Project");

            entity.HasOne(d => d.Status).WithMany(p => p.ExportOrders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExportOrder_Status");

            entity.HasOne(d => d.Storage).WithMany(p => p.ExportOrders)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.ExportOrders).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ExportOrderDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId);

            entity.ToTable("ExportOrderDetail");

            entity.HasOne(d => d.Export).WithMany(p => p.ExportOrderDetails).HasForeignKey(d => d.ExportId);

            entity.HasOne(d => d.Goods).WithMany(p => p.ExportOrderDetails)
                .HasForeignKey(d => d.GoodsId)
                .HasConstraintName("FK_ExportOrderDetail_Goods");
        });

        modelBuilder.Entity<Feature>(entity =>
        {
            entity.Property(e => e.FeatureId).HasColumnName("featureId");
            entity.Property(e => e.Featurename)
                .HasMaxLength(50)
                .HasColumnName("featurename");
            entity.Property(e => e.Url).HasColumnName("url");
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.GoodsId);

            entity.Property(e => e.Barcode).HasMaxLength(24);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.GoodsCode).HasMaxLength(24);
            entity.Property(e => e.GoodsName).HasMaxLength(100);
            entity.Property(e => e.MeasuredUnit).HasMaxLength(100);
            entity.Property(e => e.WarrantyTime).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

            entity.HasOne(d => d.Category).WithMany(p => p.Goods).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Status).WithMany(p => p.Goods)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Goods_Status");

            entity.HasOne(d => d.Storage).WithMany(p => p.Goods)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Goods).HasForeignKey(d => d.SupplierId);
        });

        modelBuilder.Entity<GoodsHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId);

            entity.ToTable("GoodsHistory");

            entity.Property(e => e.ActionCode).HasMaxLength(50);
            entity.Property(e => e.CostPriceDifferential).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(250);
            entity.Property(e => e.QuantityDifferential).HasMaxLength(11);

            entity.HasOne(d => d.Action).WithMany(p => p.GoodsHistories).HasForeignKey(d => d.ActionId);

            entity.HasOne(d => d.Goods).WithMany(p => p.GoodsHistories).HasForeignKey(d => d.GoodsId);

            entity.HasOne(d => d.User).WithMany(p => p.GoodsHistories).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ImportOrder>(entity =>
        {
            entity.HasKey(e => e.ImportId);

            entity.ToTable("ImportOrder");

            entity.Property(e => e.Image)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.ImportCode).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(250);

            entity.HasOne(d => d.Delivery).WithMany(p => p.ImportOrders)
                .HasForeignKey(d => d.DeliveryId)
                .HasConstraintName("FK_ImportOrder_Delivery");

            entity.HasOne(d => d.Project).WithMany(p => p.ImportOrders)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_ImportOrder_Project");

            entity.HasOne(d => d.Status).WithMany(p => p.ImportOrders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImportOrder_Status");

            entity.HasOne(d => d.Storage).WithMany(p => p.ImportOrders)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Supplier).WithMany(p => p.ImportOrders)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.ImportOrders).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ImportOrderDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId);

            entity.ToTable("ImportOrderDetail");

            entity.HasOne(d => d.Goods).WithMany(p => p.ImportOrderDetails)
                .HasForeignKey(d => d.GoodsId)
                .HasConstraintName("FK_ImportOrderDetail_Goods");

            entity.HasOne(d => d.Import).WithMany(p => p.ImportOrderDetails).HasForeignKey(d => d.ImportId);
        });

        modelBuilder.Entity<MeasuredUnit>(entity =>
        {
            entity.ToTable("MeasuredUnit");

            entity.Property(e => e.MeasuredUnitName).HasMaxLength(100);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.ProjectId).ValueGeneratedNever();
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.TokenId);

            entity.ToTable("RefreshToken");

            entity.Property(e => e.IsRevoked)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.JwtId).HasMaxLength(36);
            entity.Property(e => e.Token).HasMaxLength(44);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ReturnsOrder>(entity =>
        {
            entity.HasKey(e => e.ReturnsId);

            entity.ToTable("ReturnsOrder");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Note).HasMaxLength(250);
            entity.Property(e => e.ReturnsCode).HasMaxLength(50);

            entity.HasOne(d => d.Export).WithMany(p => p.ReturnsOrders).HasForeignKey(d => d.ExportId);

            entity.HasOne(d => d.Import).WithMany(p => p.ReturnsOrders).HasForeignKey(d => d.ImportId);

            entity.HasOne(d => d.Status).WithMany(p => p.ReturnsOrders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReturnsOrder_Status");

            entity.HasOne(d => d.Storage).WithMany(p => p.ReturnsOrders).HasForeignKey(d => d.StorageId);

            entity.HasOne(d => d.Supplier).WithMany(p => p.ReturnsOrders).HasForeignKey(d => d.SupplierId);

            entity.HasOne(d => d.User).WithMany(p => p.ReturnsOrders).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ReturnsOrderDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId);

            entity.ToTable("ReturnsOrderDetail");

            entity.HasOne(d => d.Goods).WithMany(p => p.ReturnsOrderDetails).HasForeignKey(d => d.GoodsId);

            entity.HasOne(d => d.Returns).WithMany(p => p.ReturnsOrderDetails).HasForeignKey(d => d.ReturnsId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleName).HasMaxLength(100);

            entity.HasMany(d => d.Features).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleFeature",
                    r => r.HasOne<Feature>().WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RoleFeature_Features"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RoleFeature_Role"),
                    j =>
                    {
                        j.HasKey("RoleId", "FeatureId");
                        j.ToTable("RoleFeature");
                    });
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusType).HasMaxLength(50);
        });

        modelBuilder.Entity<StocktakeNote>(entity =>
        {
            entity.HasKey(e => e.StocktakeId);

            entity.ToTable("StocktakeNote");

            entity.Property(e => e.Note).HasMaxLength(250);
            entity.Property(e => e.StocktakeCode).HasMaxLength(50);

            entity.HasOne(d => d.CreatedNavigation).WithMany(p => p.StocktakeNoteCreatedNavigations).HasForeignKey(d => d.CreatedId);

            entity.HasOne(d => d.Status).WithMany(p => p.StocktakeNotes)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StocktakeNote_Status");

            entity.HasOne(d => d.Storage).WithMany(p => p.StocktakeNotes)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UpdatedNavigation).WithMany(p => p.StocktakeNoteUpdatedNavigations).HasForeignKey(d => d.UpdatedId);
        });

        modelBuilder.Entity<StocktakeNoteDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId);

            entity.ToTable("StocktakeNoteDetail");

            entity.Property(e => e.Note).HasMaxLength(250);

            entity.HasOne(d => d.Goods).WithMany(p => p.StocktakeNoteDetails).HasForeignKey(d => d.GoodsId);

            entity.HasOne(d => d.Stocktake).WithMany(p => p.StocktakeNoteDetails).HasForeignKey(d => d.StocktakeId);
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.ToTable("Storage");

            entity.Property(e => e.StorageAddress).HasMaxLength(100);
            entity.Property(e => e.StorageName).HasMaxLength(100);
            entity.Property(e => e.StoragePhone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.Note).HasMaxLength(250);
            entity.Property(e => e.SupplierEmail).HasMaxLength(62);
            entity.Property(e => e.SupplierName).HasMaxLength(100);
            entity.Property(e => e.SupplierPhone).HasMaxLength(15);

            entity.HasOne(d => d.Status).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_Status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(62);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(32);
            entity.Property(e => e.StatusId).HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.UserCode).HasMaxLength(24);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Status");

            entity.HasOne(d => d.Storage).WithMany(p => p.Users)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
