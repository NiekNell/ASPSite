using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspSite.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urgencies",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    Descr = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urgencies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "toDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    task = table.Column<string>(type: "TEXT", nullable: false),
                    urgencyId = table.Column<int>(type: "INTEGER", nullable: false),
                    isDone = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_toDos_Urgencies_urgencyId",
                        column: x => x.urgencyId,
                        principalTable: "Urgencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_toDos_urgencyId",
                table: "toDos",
                column: "urgencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "toDos");

            migrationBuilder.DropTable(
                name: "Urgencies");
        }
    }
}
