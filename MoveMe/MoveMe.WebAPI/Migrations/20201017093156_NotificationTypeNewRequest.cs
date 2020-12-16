using Microsoft.EntityFrameworkCore.Migrations;

namespace MoveMe.WebAPI.Migrations
{
    public partial class NotificationTypeNewRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2be88243-0931-4f52-8cd0-f5c31b7da6c1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "98f170b1-9660-4eb0-9474-216040d709ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "982042cb-d231-456b-816c-58f2c2ab25e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cf59f6aa-d778-4438-af09-2542ff13012b", "AQAAAAEAACcQAAAAEHGOULzVWvPiBjqNSRThDoXCrF0XvsjS2WwA4G+4uTN+y0slgW4nXkVMjnkBb2vztA==" });

            migrationBuilder.InsertData(
                table: "NotificationType",
                columns: new[] { "NotificationTypeId", "Type" },
                values: new object[] { 1, "New request" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationType",
                keyColumn: "NotificationTypeId",
                keyValue: 1);

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
    }
}
