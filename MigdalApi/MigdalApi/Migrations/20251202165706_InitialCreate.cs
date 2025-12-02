using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigdalApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MisparMosach = table.Column<int>(type: "int", nullable: false),
                    ShemMosach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodSugMosach = table.Column<int>(type: "int", nullable: false),
                    SugMosach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ktovet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yishuv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mikud = table.Column<int>(type: "int", nullable: false),
                    CodMiktzoa = table.Column<int>(type: "int", nullable: false),
                    Miktzoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenahelMiktzoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RashamHavarot = table.Column<long>(type: "bigint", nullable: false),
                    Testime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garages");
        }
    }
}
