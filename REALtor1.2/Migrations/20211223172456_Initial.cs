using Microsoft.EntityFrameworkCore.Migrations;

namespace REALtor1._2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coldWater = table.Column<bool>(type: "bit", nullable: true),
                    hotWater = table.Column<bool>(type: "bit", nullable: true),
                    electricity = table.Column<bool>(type: "bit", nullable: true),
                    gas = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountOfRooms = table.Column<int>(type: "int", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusOfHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Square = table.Column<double>(type: "float", nullable: true),
                    Despription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Sellerid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.id);
                    table.ForeignKey(
                        name: "FK_House_Person_Sellerid",
                        column: x => x.Sellerid,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_House_Sellerid",
                table: "House",
                column: "Sellerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
