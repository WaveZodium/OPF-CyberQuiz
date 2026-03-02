using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberQuiz.UI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubCategories_CategoryId_OrderIndex",
                table: "SubCategories");

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                table: "SubCategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId_OrderIndex",
                table: "SubCategories",
                columns: new[] { "CategoryId", "OrderIndex" },
                unique: true,
                filter: "[OrderIndex] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubCategories_CategoryId_OrderIndex",
                table: "SubCategories");

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                table: "SubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId_OrderIndex",
                table: "SubCategories",
                columns: new[] { "CategoryId", "OrderIndex" },
                unique: true);
        }
    }
}
