using Microsoft.EntityFrameworkCore.Migrations;

namespace MoveMe.WebAPI.Migrations
{
    public partial class SupplierToRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Rating",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Rating_SupplierId",
                table: "Rating",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_AspNetUsers_SupplierId",
                table: "Rating",
                column: "SupplierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_AspNetUsers_SupplierId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_SupplierId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Rating");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bac6f665-a47e-4edd-82b9-39fe24ebff24");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e077b38f-e893-49b9-845a-0e7204f5017b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "37f47d08-cf52-44ac-8802-3d3a77ac70af");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "346ec6e3-4467-486d-963f-66f648329783", "AQAAAAEAACcQAAAAECPvp7gQ22QzwjJQYWyYd2aruFjxjrQNhvHiNYcWpiiD8gXDzY1yN+frXxwpc7jsiA==" });
        }
    }
}
