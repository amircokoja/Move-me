using Microsoft.EntityFrameworkCore.Migrations;

namespace MoveMe.WebAPI.Migrations
{
    public partial class AddInactiveRequets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Inactive",
                table: "Rating",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c767190f-f6ef-4e0c-a214-c0b05c5c34ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "16dfcac9-9685-4cf8-9e5b-f5a2c71c3ee9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e4f001c1-2997-4c46-b5c6-facecdd57532");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "43d00f2d-a840-4229-81eb-6a3abd4998b4", "AQAAAAEAACcQAAAAEMN4CD9fy7N061CGjMNpmqyzKqVuxO1uFqZUopP6UspifemVJneQtPVVpZftmUT3hw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inactive",
                table: "Rating");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b9704749-e387-4c88-9a14-aa5b1aa6685a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "abd305ac-c16c-4e10-aef9-2e277ec2c29c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2ed494b9-9376-44d6-ad7b-0f0838932128");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d5a2666-6cfa-400a-b103-e3206928c1f7", "AQAAAAEAACcQAAAAEHxIKW7RBzbeV+7BKuoXyW3UFeijuFonc1Y5J14n7Uv00Do0JrWO6/eRsCx31PQgng==" });
        }
    }
}
