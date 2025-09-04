using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspSite.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedUrgency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descr",
                table: "Urgencies",
                newName: "descr");

            migrationBuilder.InsertData(
                table: "Urgencies",
                columns: new[] { "id", "descr", "level" },
                values: new object[,]
                {
                    { 1, "Lowest", 1 },
                    { 2, "Low", 2 },
                    { 3, "Medium", 3 },
                    { 4, "High", 4 },
                    { 5, "Highest", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Urgencies",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Urgencies",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Urgencies",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Urgencies",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Urgencies",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "descr",
                table: "Urgencies",
                newName: "Descr");
        }
    }
}
