using Microsoft.EntityFrameworkCore.Migrations;

namespace REALtor1._2.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeWord",
                table: "House",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9e70088-f003-4dd2-ae7f-b6fd6b8239d5",
                column: "ConcurrencyStamp",
                value: "f0a4fd8a-3843-4a7c-8046-19b2265f983b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "586347a0-0208-44e2-b3cc-86138a23a89e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "04ba51df-de6f-4ef5-ac9a-09bdd0034652", "AQAAAAEAACcQAAAAEP4Ul1xIAzMGrB6dYfdFdDIo514dBjwrCiJFUiwNzwe8/f1V1iZMDVfNaeLOqhcyyw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeWord",
                table: "House");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9e70088-f003-4dd2-ae7f-b6fd6b8239d5",
                column: "ConcurrencyStamp",
                value: "11f8d1ad-91a8-4fdc-bc70-d3e24be51fcc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "586347a0-0208-44e2-b3cc-86138a23a89e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c33739c7-6920-4b11-a531-f2a77bb17c15", "AQAAAAEAACcQAAAAEIdjcMirelLk1l4Tf9NMlkOoJr7b2pRLk5Qysc3mOzyIYp4OyNA/qdZgliXXLm7JZw==" });
        }
    }
}
