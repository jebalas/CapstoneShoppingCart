using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneWk4ShoppingList.Migrations
{
    public partial class AddProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Price", "Name" },
                values: new object[] { 1, 39.99m, "Geometry for Dummies" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Price", "Name" },
                values: new object[] { 2, 29.99m, "Algebra for Dummies" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Price", "Name" },
                values: new object[] { 3, 49.99m, "Calculus for Dummies" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);
        }
    }
}
