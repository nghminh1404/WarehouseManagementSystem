using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WM.Entity.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchoolDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionType",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionType", x => x.ActionId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    DeliveyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.DeliveyId);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    featureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    featurename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.featureId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    StorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StorageAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.StorageId);
                });

            migrationBuilder.CreateTable(
                name: "RoleFeature",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false),
                    featureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFeature", x => new { x.roleId, x.featureId });
                    table.ForeignKey(
                        name: "FK_RoleFeature_Features",
                        column: x => x.featureId,
                        principalTable: "Features",
                        principalColumn: "featureId");
                    table.ForeignKey(
                        name: "FK_RoleFeature_Role",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Loads",
                columns: table => new
                {
                    LoadsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoadsCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GoodsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    statusId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryId = table.Column<int>(type: "int", nullable: true),
                    isPaid = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loads", x => x.LoadsId);
                    table.ForeignKey(
                        name: "FK_Loads_Delivery",
                        column: x => x.DeliveryId,
                        principalTable: "Delivery",
                        principalColumn: "DeliveyId");
                    table.ForeignKey(
                        name: "FK_Loads_Status",
                        column: x => x.statusId,
                        principalTable: "Status",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SupplierPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    SupplierEmail = table.Column<string>(type: "nvarchar(62)", maxLength: 62, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StorageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Supplier_Status",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK_Supplier_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(62)", maxLength: 62, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Status",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK_User_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId");
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    GoodsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GoodsCode = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CostPrice = table.Column<float>(type: "real", nullable: false),
                    DefaultMeasuredUnit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    StockPrice = table.Column<float>(type: "real", nullable: false),
                    WarrantyTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "('0001-01-01T00:00:00.0000000')"),
                    Barcode = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    MaxStock = table.Column<int>(type: "int", nullable: true),
                    MinStock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GoodsId);
                    table.ForeignKey(
                        name: "FK_Goods_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goods_Status",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK_Goods_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId");
                    table.ForeignKey(
                        name: "FK_Goods_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailToken",
                columns: table => new
                {
                    TokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailToken", x => x.TokenId);
                    table.ForeignKey(
                        name: "FK_EmailToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportOrder",
                columns: table => new
                {
                    ExportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Completed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Denied = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportOrder", x => x.ExportId);
                    table.ForeignKey(
                        name: "FK_ExportOrder_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId");
                    table.ForeignKey(
                        name: "FK_ExportOrder_Status",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK_ExportOrder_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId");
                    table.ForeignKey(
                        name: "FK_ExportOrder_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportOrder",
                columns: table => new
                {
                    ImportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    TotalCost = table.Column<float>(type: "real", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Completed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ImportCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportOrder", x => x.ImportId);
                    table.ForeignKey(
                        name: "FK_ImportOrder_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId");
                    table.ForeignKey(
                        name: "FK_ImportOrder_Status",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK_ImportOrder_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId");
                    table.ForeignKey(
                        name: "FK_ImportOrder_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId");
                    table.ForeignKey(
                        name: "FK_ImportOrder_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    TokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(44)", maxLength: 44, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    JwtId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.TokenId);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StocktakeNote",
                columns: table => new
                {
                    StocktakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Canceled = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UpdatedId = table.Column<int>(type: "int", nullable: true),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedId = table.Column<int>(type: "int", nullable: false),
                    StocktakeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocktakeNote", x => x.StocktakeId);
                    table.ForeignKey(
                        name: "FK_StocktakeNote_Status",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK_StocktakeNote_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId");
                    table.ForeignKey(
                        name: "FK_StocktakeNote_User_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StocktakeNote_User_UpdatedId",
                        column: x => x.UpdatedId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "GoodsHistory",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostPrice = table.Column<float>(type: "real", nullable: true),
                    CostPriceDifferential = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    PriceDifferential = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    AmountDifferential = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsHistory", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_GoodsHistory_ActionType_ActionId",
                        column: x => x.ActionId,
                        principalTable: "ActionType",
                        principalColumn: "ActionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsHistory_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsHistory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeasuredUnit",
                columns: table => new
                {
                    MeasuredUnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsId = table.Column<int>(type: "int", nullable: false),
                    MeasuredUnitName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MeasuredUnitValue = table.Column<int>(type: "int", nullable: false),
                    SuggestedPrice = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuredUnit", x => x.MeasuredUnitId);
                    table.ForeignKey(
                        name: "FK_MeasuredUnit_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportOrderDetail",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExportId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    LoadsId = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<int>(type: "int", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportOrderDetail", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_ExportOrderDetail_ExportOrder_ExportId",
                        column: x => x.ExportId,
                        principalTable: "ExportOrder",
                        principalColumn: "ExportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableForReturns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportId = table.Column<int>(type: "int", nullable: true),
                    ExportId = table.Column<int>(type: "int", nullable: true),
                    GoodsId = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableForReturns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableForReturns_ExportOrder_ExportId",
                        column: x => x.ExportId,
                        principalTable: "ExportOrder",
                        principalColumn: "ExportId");
                    table.ForeignKey(
                        name: "FK_AvailableForReturns_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "GoodsId");
                    table.ForeignKey(
                        name: "FK_AvailableForReturns_ImportOrder_ImportId",
                        column: x => x.ImportId,
                        principalTable: "ImportOrder",
                        principalColumn: "ImportId");
                });

            migrationBuilder.CreateTable(
                name: "ImportOrderDetail",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportId = table.Column<int>(type: "int", nullable: false),
                    CostPrice = table.Column<float>(type: "real", nullable: false),
                    LoadsId = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<int>(type: "int", nullable: true),
                    imagee = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportOrderDetail", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_ImportOrderDetail_ImportOrder_ImportId",
                        column: x => x.ImportId,
                        principalTable: "ImportOrder",
                        principalColumn: "ImportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnsOrder",
                columns: table => new
                {
                    ReturnsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportId = table.Column<int>(type: "int", nullable: true),
                    ExportId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "('0001-01-01T00:00:00.0000000')"),
                    ReturnsCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Imported = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnsOrder", x => x.ReturnsId);
                    table.ForeignKey(
                        name: "FK_ReturnsOrder_ExportOrder_ExportId",
                        column: x => x.ExportId,
                        principalTable: "ExportOrder",
                        principalColumn: "ExportId");
                    table.ForeignKey(
                        name: "FK_ReturnsOrder_ImportOrder_ImportId",
                        column: x => x.ImportId,
                        principalTable: "ImportOrder",
                        principalColumn: "ImportId");
                    table.ForeignKey(
                        name: "FK_ReturnsOrder_Status",
                        column: x => x.State,
                        principalTable: "Status",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK_ReturnsOrder_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnsOrder_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId");
                    table.ForeignKey(
                        name: "FK_ReturnsOrder_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StocktakeNoteDetail",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StocktakeId = table.Column<int>(type: "int", nullable: false),
                    GoodsId = table.Column<int>(type: "int", nullable: false),
                    CurrentStock = table.Column<int>(type: "int", nullable: false),
                    ActualStock = table.Column<int>(type: "int", nullable: false),
                    AmountDifferential = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocktakeNoteDetail", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_StocktakeNoteDetail_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StocktakeNoteDetail_StocktakeNote_StocktakeId",
                        column: x => x.StocktakeId,
                        principalTable: "StocktakeNote",
                        principalColumn: "StocktakeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnsOrderDetail",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnsId = table.Column<int>(type: "int", nullable: false),
                    GoodsId = table.Column<int>(type: "int", nullable: false),
                    MeasuredUnitId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnsOrderDetail", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_ReturnsOrderDetail_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnsOrderDetail_MeasuredUnit_MeasuredUnitId",
                        column: x => x.MeasuredUnitId,
                        principalTable: "MeasuredUnit",
                        principalColumn: "MeasuredUnitId");
                    table.ForeignKey(
                        name: "FK_ReturnsOrderDetail_ReturnsOrder_ReturnsId",
                        column: x => x.ReturnsId,
                        principalTable: "ReturnsOrder",
                        principalColumn: "ReturnsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableForReturns_ExportId",
                table: "AvailableForReturns",
                column: "ExportId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableForReturns_GoodsId",
                table: "AvailableForReturns",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableForReturns_ImportId",
                table: "AvailableForReturns",
                column: "ImportId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailToken_UserId",
                table: "EmailToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportOrder_ProjectId",
                table: "ExportOrder",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportOrder_StatusId",
                table: "ExportOrder",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportOrder_StorageId",
                table: "ExportOrder",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportOrder_UserId",
                table: "ExportOrder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportOrderDetail_ExportId",
                table: "ExportOrderDetail",
                column: "ExportId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_CategoryId",
                table: "Goods",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_StatusId",
                table: "Goods",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_StorageId",
                table: "Goods",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_SupplierId",
                table: "Goods",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsHistory_ActionId",
                table: "GoodsHistory",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsHistory_GoodsId",
                table: "GoodsHistory",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsHistory_UserId",
                table: "GoodsHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportOrder_ProjectId",
                table: "ImportOrder",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportOrder_StatusId",
                table: "ImportOrder",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportOrder_StorageId",
                table: "ImportOrder",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportOrder_SupplierId",
                table: "ImportOrder",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportOrder_UserId",
                table: "ImportOrder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportOrderDetail_ImportId",
                table: "ImportOrderDetail",
                column: "ImportId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_DeliveryId",
                table: "Loads",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_statusId",
                table: "Loads",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuredUnit_GoodsId",
                table: "MeasuredUnit",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsOrder_ExportId",
                table: "ReturnsOrder",
                column: "ExportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsOrder_ImportId",
                table: "ReturnsOrder",
                column: "ImportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsOrder_State",
                table: "ReturnsOrder",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsOrder_StorageId",
                table: "ReturnsOrder",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsOrder_SupplierId",
                table: "ReturnsOrder",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsOrder_UserId",
                table: "ReturnsOrder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsOrderDetail_GoodsId",
                table: "ReturnsOrderDetail",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsOrderDetail_MeasuredUnitId",
                table: "ReturnsOrderDetail",
                column: "MeasuredUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnsOrderDetail_ReturnsId",
                table: "ReturnsOrderDetail",
                column: "ReturnsId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFeature_featureId",
                table: "RoleFeature",
                column: "featureId");

            migrationBuilder.CreateIndex(
                name: "IX_StocktakeNote_CreatedId",
                table: "StocktakeNote",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_StocktakeNote_StatusId",
                table: "StocktakeNote",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StocktakeNote_StorageId",
                table: "StocktakeNote",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_StocktakeNote_UpdatedId",
                table: "StocktakeNote",
                column: "UpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_StocktakeNoteDetail_GoodsId",
                table: "StocktakeNoteDetail",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_StocktakeNoteDetail_StocktakeId",
                table: "StocktakeNoteDetail",
                column: "StocktakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_StatusId",
                table: "Supplier",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_StorageId",
                table: "Supplier",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StatusId",
                table: "User",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StorageId",
                table: "User",
                column: "StorageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableForReturns");

            migrationBuilder.DropTable(
                name: "EmailToken");

            migrationBuilder.DropTable(
                name: "ExportOrderDetail");

            migrationBuilder.DropTable(
                name: "GoodsHistory");

            migrationBuilder.DropTable(
                name: "ImportOrderDetail");

            migrationBuilder.DropTable(
                name: "Loads");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "ReturnsOrderDetail");

            migrationBuilder.DropTable(
                name: "RoleFeature");

            migrationBuilder.DropTable(
                name: "StocktakeNoteDetail");

            migrationBuilder.DropTable(
                name: "ActionType");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "MeasuredUnit");

            migrationBuilder.DropTable(
                name: "ReturnsOrder");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "StocktakeNote");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "ExportOrder");

            migrationBuilder.DropTable(
                name: "ImportOrder");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Storage");
        }
    }
}
