using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoveMe.WebAPI.Migrations
{
    public partial class NotificationsTypeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
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

            migrationBuilder.InsertData(
                table: "NotificationType",
                columns: new[] { "NotificationTypeId", "Type" },
                values: new object[,]
                {
                    { 4, "Offer finished" },
                    { 5, "Feedback" }
                });

            migrationBuilder.InsertData(
                table: "OfferStatus",
                columns: new[] { "OfferStatusId", "Name" },
                values: new object[] { 4, "Finished" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationType",
                keyColumn: "NotificationTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NotificationType",
                keyColumn: "NotificationTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OfferStatus",
                keyColumn: "OfferStatusId",
                keyValue: 4);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Rating",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }
    }
}
