using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestiaryApi.Migrations
{
    public partial class ModelRevision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Variations = table.Column<string>(type: "TEXT", nullable: true),
                    Occurrences = table.Column<string>(type: "TEXT", nullable: true),
                    Vulnerable = table.Column<string>(type: "TEXT", nullable: true),
                    Immunity = table.Column<string>(type: "TEXT", nullable: true),
                    Loot = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beasts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beasts");
        }
    }
}
