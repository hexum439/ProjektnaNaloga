using Microsoft.EntityFrameworkCore.Migrations;

namespace SecondHand.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KategorijeCevljis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeKategorije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spol = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijeCevljis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KategorijeOblacilas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeKategorije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spol = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijeOblacilas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Obutevs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeCevlja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlikaCevljaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StCevlja = table.Column<double>(type: "float", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    znamka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obutevs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obutevs_KategorijeCevljis_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "KategorijeCevljis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oblacilas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeOblacila = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlikaOblekeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oblacilas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oblacilas_KategorijeOblacilas_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "KategorijeOblacilas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oblacilas_KategorijaId",
                table: "Oblacilas",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obutevs_KategorijaId",
                table: "Obutevs",
                column: "KategorijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oblacilas");

            migrationBuilder.DropTable(
                name: "Obutevs");

            migrationBuilder.DropTable(
                name: "KategorijeOblacilas");

            migrationBuilder.DropTable(
                name: "KategorijeCevljis");
        }
    }
}
