using Microsoft.EntityFrameworkCore.Migrations;

namespace MoveMe.WebAPI.Migrations
{
    public partial class TransportDistanceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransportDistanceApprox",
                table: "Request",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3358e1ba-9c03-44e2-8316-c71bd0a6d39d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f9f81b76-8890-40b2-b1da-e043fa9b302b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c6613dd7-06c3-4ee3-b83f-de705f4f44ec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6d1bf44-a0fa-4f9c-80f3-178809151c96", "AQAAAAEAACcQAAAAEHP27U/CO+maXtFDHqa5Pk3c6e/EsBpXeGnlH+T+yFl5hReuWA/wGEzStr1tScO47Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransportDistanceApprox",
                table: "Request");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ac96b086-d2b1-4abd-8d38-41ed71576563");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1e0bf45d-54e1-4292-8e6e-986fdf10fba5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "ce88c211-8302-49c3-a99b-dd638c28b304");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17a3e49a-234c-48b4-92c7-724f88162e7f", "AQAAAAEAACcQAAAAEF5IerjnzGkpGIOtT56pyL6LvzPGnzy1i6oyMmVohsdUntLYncjkB3VUKWxUYm66pA==" });
        }
    }
}
