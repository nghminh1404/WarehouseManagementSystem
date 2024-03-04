using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WM.Entity.Migrations
{
    /// <inheritdoc />
    public partial class InitialWMSDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodsId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Loads");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Role",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "LoadsGoods",
                columns: table => new
                {
                    LoadsId = table.Column<int>(type: "int", nullable: false),
                    GoodsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadsGoods", x => new { x.LoadsId, x.GoodsId });
                    table.ForeignKey(
                        name: "FK_LoadsGoods_Goods",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "GoodsId");
                    table.ForeignKey(
                        name: "FK_LoadsGoods_Loads",
                        column: x => x.LoadsId,
                        principalTable: "Loads",
                        principalColumn: "LoadsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loads_StorageId",
                table: "Loads",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Loads_UserId",
                table: "Loads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadsGoods_GoodsId",
                table: "LoadsGoods",
                column: "GoodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_Storage",
                table: "Loads",
                column: "StorageId",
                principalTable: "Storage",
                principalColumn: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_User",
                table: "Loads",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_Storage",
                table: "Loads");

            migrationBuilder.DropForeignKey(
                name: "FK_Loads_User",
                table: "Loads");

            migrationBuilder.DropTable(
                name: "LoadsGoods");

            migrationBuilder.DropIndex(
                name: "IX_Loads_StorageId",
                table: "Loads");

            migrationBuilder.DropIndex(
                name: "IX_Loads_UserId",
                table: "Loads");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Role",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GoodsId",
                table: "Loads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Loads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
