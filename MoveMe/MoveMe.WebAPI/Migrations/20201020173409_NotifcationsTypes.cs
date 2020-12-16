using Microsoft.EntityFrameworkCore.Migrations;

namespace MoveMe.WebAPI.Migrations
{
    public partial class NotifcationsTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d1052b5f-1618-4ecb-9143-48d6cd73c4af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "97102ebe-0596-49b5-81d1-24629bca7b14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "1384a1a6-7aa4-4966-a639-7db572893f76");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c862c994-b4ec-4b7d-ae25-71b4e7bd3b83", "AQAAAAEAACcQAAAAEOewexg6cmvo0G7kDQrz+e99pZqxA2QfX/UpNfFiHOxRuyOff6r+V4CX6Wm7xizVFA==" });

            migrationBuilder.InsertData(
                table: "NotificationType",
                columns: new[] { "NotificationTypeId", "Type" },
                values: new object[,]
                {
                    { 2, "Offer accepted" },
                    { 3, "Offer rejected" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationType",
                keyColumn: "NotificationTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NotificationType",
                keyColumn: "NotificationTypeId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "de81d12b-8ad1-44f0-ad1e-12a73b26577c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "357c92c5-672c-46e9-a0aa-2ca9d7470436");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "1b7cf855-729b-4b32-91b9-feef387fc412");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd100ab1-67db-4dbb-be1b-053ce94a86e4", "AQAAAAEAACcQAAAAEOY9ffw95NW586KnqiDxLnzCQp//ea8Dz+sJBD3aTgcj1MIbsvDjnFAU6IdP4ZyV9w==" });
        }
    }
}
