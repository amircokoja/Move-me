using Microsoft.EntityFrameworkCore.Migrations;

namespace MoveMe.WebAPI.Migrations
{
    public partial class AddInactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inactive",
                table: "Rating");

            migrationBuilder.AddColumn<bool>(
                name: "Inactive",
                table: "Request",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1e1671d2-7ca2-4eb0-ad44-916e3a284cf4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0ceba7ee-4744-43e7-bdbb-2781a8655e91");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "1ee53a22-91b2-40b5-bc80-edb96df1ac70");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8d4553a-c7fd-4e99-8c23-581485902ad7", "AQAAAAEAACcQAAAAENSFLCyy2XMT4LP0daor4Gct4cReFvncxxOSADZLInj34Q1yvVLeND4juLDPPqooug==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inactive",
                table: "Request");

            migrationBuilder.AddColumn<bool>(
                name: "Inactive",
                table: "Rating",
                type: "bit",
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
    }
}
