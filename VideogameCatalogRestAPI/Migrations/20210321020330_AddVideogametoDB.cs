using Microsoft.EntityFrameworkCore.Migrations;

namespace VideogameCatalogRestAPI.Migrations
{
    public partial class AddVideogametoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videogames",
                columns: table => new
                {
                    VideogameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideogameName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Genere = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PublisherName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogames", x => x.VideogameId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videogames");
        }
    }
}
