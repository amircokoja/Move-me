using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoveMe.WebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "NotificationType",
                columns: table => new
                {
                    NotificationTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationType", x => x.NotificationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "OfferStatus",
                columns: table => new
                {
                    OfferStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferStatus", x => x.OfferStatusId);
                });

            migrationBuilder.CreateTable(
                name: "RatingType",
                columns: table => new
                {
                    RatingTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingType", x => x.RatingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(maxLength: 70, nullable: true),
                    City = table.Column<string>(maxLength: 70, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 15, nullable: true),
                    AdditionalAddress = table.Column<string>(maxLength: 70, nullable: true),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK__Address__Country__267ABA7A",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 16, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Company = table.Column<string>(maxLength: 70, nullable: true),
                    FirstName = table.Column<string>(maxLength: 40, nullable: true),
                    LastName = table.Column<string>(maxLength: 40, nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK__User__AddressId__29572725",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserToId = table.Column<int>(nullable: false),
                    UserFromId = table.Column<int>(nullable: false),
                    NotificationTypeId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notification_NotificationType_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationType",
                        principalColumn: "NotificationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_UserFromId",
                        column: x => x.UserFromId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_UserToId",
                        column: x => x.UserToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: true),
                    Rooms = table.Column<int>(nullable: true),
                    TotalWeightApprox = table.Column<int>(nullable: true),
                    AdditionalInformation = table.Column<string>(maxLength: 300, nullable: true),
                    ClientId = table.Column<int>(nullable: true),
                    DeliveryAddress = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    Inactive = table.Column<bool>(nullable: false),
                    TransportDistanceApprox = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK__Request__ClientI__2F10007B",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Request__Deliver__300424B4",
                        column: x => x.DeliveryAddress,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Request__StatusI__30F848ED",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    OfferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    OfferStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offer_OfferStatus_OfferStatusId",
                        column: x => x.OfferStatusId,
                        principalTable: "OfferStatus",
                        principalColumn: "OfferStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offer_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    RequestId = table.Column<int>(nullable: true),
                    RatingTypeId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK__Rating__RatingTy__37A5467C",
                        column: x => x.RatingTypeId,
                        principalTable: "RatingType",
                        principalColumn: "RatingTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Rating__RequestI__36B12243",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_AspNetUsers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "7e07e476-a70a-4181-8608-18ec9bc4b8e7", "Admin", "ADMIN" },
                    { 2, "bc3660b5-ddc4-402c-a756-71c941b6a339", "Client", "CLIENT" },
                    { 3, "d84609fc-7f04-44dd-9c82-76a54afad2bc", "Supplier", "SUPPLIER" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 17, "Netherlands" },
                    { 18, "Norway" },
                    { 19, "Poland" },
                    { 20, "Portugal" },
                    { 22, "Serbia" },
                    { 23, "Slovenia" },
                    { 24, "Spain" },
                    { 25, "Sweden" },
                    { 26, "Switzerland" },
                    { 27, "Turkey" },
                    { 28, "Ukraine" },
                    { 29, "United Kingdom" },
                    { 16, "Montenegro" },
                    { 15, "Luxembourg" },
                    { 21, "Russia" },
                    { 13, "Ireland" },
                    { 12, "Iceland" },
                    { 11, "Hungary" },
                    { 10, "Greece" },
                    { 9, "Germany" },
                    { 8, "France" },
                    { 7, "Finland" },
                    { 6, "Denmark" },
                    { 5, "Croatia" },
                    { 4, "Bosnia and Herzegovina" },
                    { 3, "Belgium" },
                    { 2, "Austria" },
                    { 1, "Albania" },
                    { 14, "Italy" }
                });

            migrationBuilder.InsertData(
                table: "NotificationType",
                columns: new[] { "NotificationTypeId", "Type" },
                values: new object[,]
                {
                    { 5, "Feedback" },
                    { 4, "Offer finished" },
                    { 1, "New request" },
                    { 2, "Offer accepted" },
                    { 3, "Offer rejected" }
                });

            migrationBuilder.InsertData(
                table: "OfferStatus",
                columns: new[] { "OfferStatusId", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Accepted" },
                    { 3, "Rejected" },
                    { 4, "Finished" }
                });

            migrationBuilder.InsertData(
                table: "RatingType",
                columns: new[] { "RatingTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Positive" },
                    { 2, "Neutral" },
                    { 3, "Negative" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { 2, "Accepted" },
                    { 1, "Pending" },
                    { 3, "Finished" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "AdditionalAddress", "City", "CountryId", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Admin", "Admin", 1, "Admin", "10000" },
                    { 2, "No additional address", "Mostar", 4, "Brace fejica", "88000" },
                    { 4, "Trg heroja", "Sarajevo", 4, "Grbavica", "71000" },
                    { 5, "No additional address", "Konjic", 4, "Omladinska 3", "88400" },
                    { 6, "No additional address", "Makarska", 4, "Gorinka", "21300" },
                    { 8, "No additional address", "Zenica", 4, "Aleja sehida", "72000" },
                    { 3, "No additional address", "Zagreb", 5, "Rusanova ulica 3", "10000" },
                    { 7, "No additional address", "Split", 5, "Sibenska ulica 28", "21000" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "AddressId", "Company", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, 0, true, 1, null, "3bd2fcd5-700a-4d37-b95c-3303feb4666f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", null, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAyqRQA6zOSxUh/YYwRve8xRPrkbviAwlMUrXU2OJhTct5UKLDrt8sU+yOzCKK5fIA==", null, false, "", false, 0, "admin@admin.com" },
                    { 2, 0, true, 2, null, "bd8699d8-b4a9-4a08-b4fb-017f42731136", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chris.simanek@moveme.com", true, "Chris", null, "Simanek", false, null, "CHRIS.SIMANEK@MOVEME.COM", "CHRIS.SIMANEK@MOVEME.COM", "AQAAAAEAACcQAAAAECPSGWZU3l/sEeIndDP40LJKX99VNttGe+TZ7IaffXAo10d0xIailkUDXXS4RBCP9w==", null, false, "", false, 0, "chris.simanek@moveme.com" },
                    { 4, 0, true, 4, "CityS", "69743d54-8684-4d6b-827c-cd26bd15218f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "citys@moveme.com", true, null, new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 225, 0, 0, 0, 225, 8, 3, 0, 0, 0, 9, 109, 34, 72, 0, 0, 0, 153, 80, 76, 84, 69, 255, 255, 255, 102, 102, 102, 241, 134, 36, 91, 91, 91, 95, 95, 95, 88, 88, 88, 211, 211, 211, 241, 241, 241, 96, 96, 96, 99, 99, 99, 240, 126, 0, 236, 236, 236, 208, 208, 208, 252, 252, 252, 190, 190, 190, 198, 198, 198, 174, 174, 174, 167, 167, 167, 227, 227, 227, 116, 116, 116, 180, 180, 180, 242, 146, 60, 253, 243, 234, 127, 127, 127, 240, 124, 0, 241, 131, 27, 218, 218, 218, 245, 245, 245, 240, 128, 13, 82, 82, 82, 136, 136, 136, 154, 154, 154, 248, 199, 163, 119, 119, 119, 244, 163, 100, 252, 236, 223, 243, 157, 86, 250, 217, 194, 245, 171, 114, 242, 149, 70, 151, 151, 151, 249, 211, 184, 141, 141, 141, 246, 187, 143, 242, 142, 52, 245, 178, 127, 249, 205, 174, 251, 221, 201, 252, 229, 213, 247, 191, 149, 244, 168, 111, 229, 152, 187, 134, 0, 0, 5, 119, 73, 68, 65, 84, 120, 156, 237, 155, 235, 118, 162, 48, 20, 70, 141, 1, 37, 8, 222, 176, 10, 74, 171, 85, 219, 142, 173, 109, 109, 223, 255, 225, 6, 69, 59, 230, 130, 70, 41, 16, 103, 125, 251, 39, 18, 61, 123, 229, 118, 114, 177, 86, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 167, 240, 135, 9, 190, 95, 117, 24, 133, 48, 92, 189, 205, 239, 34, 55, 220, 18, 175, 151, 239, 31, 139, 170, 35, 250, 85, 62, 223, 215, 174, 27, 71, 81, 253, 64, 20, 197, 225, 176, 234, 168, 126, 141, 197, 91, 228, 254, 115, 251, 33, 222, 26, 78, 27, 85, 71, 151, 159, 205, 50, 140, 101, 189, 131, 97, 96, 7, 157, 170, 35, 204, 199, 98, 30, 42, 170, 239, 200, 144, 49, 26, 120, 85, 71, 153, 131, 119, 85, 243, 228, 13, 9, 97, 116, 212, 170, 58, 208, 43, 217, 212, 213, 237, 83, 48, 220, 58, 182, 115, 254, 212, 184, 59, 144, 232, 78, 126, 67, 226, 20, 95, 225, 9, 63, 206, 144, 16, 250, 144, 47, 156, 182, 109, 73, 220, 55, 127, 199, 35, 147, 185, 123, 82, 144, 55, 36, 14, 233, 231, 249, 177, 182, 69, 36, 236, 98, 13, 135, 119, 167, 90, 168, 108, 72, 152, 149, 103, 226, 40, 223, 112, 88, 207, 30, 98, 212, 134, 73, 68, 57, 198, 212, 210, 13, 53, 4, 101, 195, 60, 138, 169, 33, 59, 116, 193, 194, 13, 253, 245, 121, 65, 133, 33, 177, 199, 215, 254, 226, 206, 208, 106, 79, 154, 59, 38, 187, 175, 45, 210, 112, 153, 221, 7, 163, 232, 144, 157, 42, 12, 137, 115, 109, 80, 169, 225, 79, 122, 84, 180, 225, 155, 122, 20, 141, 98, 55, 140, 239, 150, 203, 151, 122, 178, 186, 136, 148, 134, 44, 184, 242, 39, 203, 53, 124, 82, 206, 131, 177, 187, 156, 109, 14, 11, 195, 197, 234, 57, 10, 21, 134, 196, 154, 94, 247, 155, 165, 26, 250, 170, 62, 232, 174, 103, 226, 98, 105, 165, 50, 36, 118, 198, 156, 209, 239, 117, 37, 122, 255, 20, 74, 53, 124, 150, 59, 97, 28, 125, 100, 188, 44, 25, 18, 162, 222, 0, 240, 84, 73, 203, 191, 36, 161, 76, 195, 141, 220, 70, 195, 231, 204, 109, 11, 217, 208, 234, 41, 95, 244, 168, 60, 225, 209, 106, 12, 239, 196, 70, 26, 185, 171, 236, 183, 91, 129, 35, 198, 109, 43, 23, 26, 230, 24, 174, 196, 42, 140, 234, 39, 55, 100, 252, 7, 49, 27, 113, 254, 168, 222, 211, 50, 28, 244, 247, 4, 164, 56, 67, 169, 10, 235, 231, 182, 99, 36, 69, 170, 170, 68, 29, 67, 98, 209, 61, 164, 56, 195, 79, 113, 42, 116, 207, 111, 169, 141, 132, 190, 232, 168, 122, 162, 150, 161, 208, 220, 11, 49, 156, 11, 85, 24, 126, 158, 47, 51, 33, 162, 162, 98, 96, 50, 197, 112, 40, 84, 97, 252, 166, 83, 106, 44, 68, 79, 21, 155, 83, 166, 24, 126, 8, 115, 225, 90, 175, 216, 148, 31, 80, 217, 131, 252, 138, 41, 134, 75, 190, 145, 186, 79, 122, 197, 124, 33, 124, 91, 222, 210, 48, 196, 208, 231, 27, 105, 244, 162, 91, 112, 192, 7, 72, 189, 90, 143, 39, 195, 112, 188, 255, 120, 82, 150, 161, 48, 146, 234, 86, 161, 84, 137, 206, 180, 54, 162, 206, 17, 247, 190, 210, 176, 213, 177, 211, 143, 91, 101, 25, 126, 241, 221, 48, 214, 47, 201, 247, 196, 100, 17, 213, 229, 66, 182, 179, 12, 247, 171, 249, 210, 12, 249, 185, 34, 122, 215, 47, 217, 224, 5, 168, 96, 244, 99, 200, 210, 25, 157, 85, 101, 200, 87, 161, 171, 49, 23, 30, 240, 249, 41, 145, 246, 91, 182, 202, 144, 77, 189, 45, 141, 71, 86, 141, 161, 207, 231, 164, 238, 37, 7, 161, 15, 156, 34, 245, 120, 229, 131, 161, 53, 72, 223, 30, 85, 100, 184, 224, 13, 239, 46, 41, 219, 229, 58, 162, 213, 174, 5, 38, 26, 110, 184, 161, 52, 154, 95, 82, 182, 195, 133, 232, 116, 107, 143, 220, 62, 163, 33, 134, 252, 100, 113, 201, 64, 35, 14, 53, 219, 233, 194, 68, 195, 21, 103, 168, 151, 147, 30, 232, 243, 134, 127, 248, 142, 105, 168, 225, 215, 245, 134, 204, 80, 195, 167, 28, 117, 56, 190, 137, 58, 204, 211, 15, 189, 155, 232, 135, 121, 198, 82, 62, 68, 171, 43, 156, 217, 24, 98, 56, 228, 231, 67, 205, 197, 97, 74, 79, 156, 15, 249, 96, 13, 49, 172, 241, 134, 23, 93, 9, 226, 55, 107, 104, 99, 162, 204, 188, 43, 55, 228, 4, 235, 241, 137, 125, 82, 17, 94, 40, 137, 189, 175, 204, 75, 157, 233, 120, 75, 191, 170, 188, 180, 246, 205, 175, 45, 190, 245, 75, 118, 248, 181, 133, 37, 228, 56, 63, 107, 11, 167, 226, 181, 197, 140, 95, 92, 132, 250, 169, 55, 159, 120, 179, 145, 208, 47, 141, 89, 31, 10, 103, 22, 241, 76, 183, 32, 191, 86, 218, 14, 165, 35, 229, 218, 162, 114, 195, 154, 120, 236, 164, 91, 78, 216, 108, 163, 227, 201, 61, 61, 230, 222, 247, 248, 7, 233, 211, 126, 39, 125, 122, 223, 106, 171, 62, 46, 194, 144, 239, 136, 218, 149, 40, 84, 97, 210, 13, 155, 94, 227, 24, 79, 124, 144, 62, 157, 180, 210, 167, 158, 223, 146, 63, 77, 158, 22, 96, 184, 18, 119, 132, 245, 38, 12, 97, 95, 95, 125, 54, 99, 6, 226, 249, 111, 180, 212, 41, 213, 22, 247, 188, 77, 190, 116, 250, 46, 244, 68, 87, 99, 129, 209, 23, 4, 25, 41, 62, 206, 235, 89, 136, 103, 79, 225, 217, 105, 191, 201, 196, 219, 10, 131, 50, 34, 189, 26, 241, 240, 169, 30, 158, 217, 22, 150, 78, 158, 136, 83, 248, 173, 201, 92, 200, 199, 248, 110, 214, 45, 133, 29, 125, 73, 48, 153, 12, 205, 70, 170, 196, 122, 120, 98, 161, 216, 161, 242, 85, 5, 211, 255, 141, 33, 30, 33, 38, 3, 106, 230, 50, 106, 242, 106, 139, 126, 202, 195, 67, 195, 152, 137, 138, 81, 198, 198, 233, 164, 107, 73, 23, 49, 182, 41, 169, 249, 188, 136, 147, 226, 214, 176, 53, 18, 82, 140, 254, 212, 81, 228, 146, 234, 107, 10, 166, 33, 182, 211, 212, 208, 166, 206, 195, 160, 209, 74, 198, 73, 191, 53, 110, 79, 9, 149, 235, 47, 193, 206, 123, 165, 189, 28, 132, 59, 53, 169, 33, 221, 94, 112, 165, 246, 14, 170, 104, 158, 233, 40, 99, 112, 190, 198, 193, 95, 191, 252, 49, 60, 11, 123, 172, 58, 114, 109, 190, 227, 107, 12, 25, 49, 123, 174, 231, 152, 199, 151, 27, 50, 86, 244, 31, 36, 126, 149, 163, 127, 91, 104, 26, 50, 114, 83, 130, 201, 42, 35, 188, 204, 208, 10, 110, 168, 137, 166, 204, 194, 75, 12, 233, 171, 233, 201, 154, 130, 205, 254, 86, 190, 134, 33, 179, 205, 94, 49, 101, 225, 207, 67, 61, 67, 43, 200, 245, 167, 167, 42, 121, 90, 187, 231, 13, 29, 227, 215, 75, 39, 153, 69, 241, 105, 67, 199, 158, 222, 216, 24, 42, 226, 207, 118, 219, 166, 106, 67, 102, 217, 211, 91, 72, 181, 207, 177, 189, 57, 164, 48, 76, 210, 212, 199, 246, 13, 142, 160, 25, 52, 9, 77, 242, 109, 182, 199, 73, 114, 112, 242, 218, 254, 31, 170, 239, 136, 102, 163, 221, 123, 29, 61, 6, 65, 48, 122, 152, 14, 188, 255, 204, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 148, 206, 95, 212, 233, 105, 194, 206, 220, 125, 233, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, null, false, null, "CITYS@MOVEME.COM", "CITYS@MOVEME.COM", "AQAAAAEAACcQAAAAENhtzYmZ0stbLUMkn8TSASa/i5/ZXFP8V4qSJ4Q0Cytxax4d5cKbDXtgza40inD8Nw==", null, false, "", false, 0, "citys@moveme.com" },
                    { 5, 0, true, 5, null, "2b67e425-e029-4909-a3af-ec2d85719e20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "albie.boyle@moveme.com", true, "Albie", null, "Boyle", false, null, "ALBIE.BOYLE@MOVEME.COM", "ALBIE.BOYLE@MOVEME.COM", "AQAAAAEAACcQAAAAELgdUPV8ugZV1tPv5PxEdDfp1aEJoyfyzBpCr1Ry2Sny381OLrr1Y70zabVhlXXQmQ==", null, false, "", false, 0, "albie.boyle@moveme.com" },
                    { 3, 0, true, 3, "Obrelo", "3e71de76-5636-4de8-a8ed-024b3b46d8f2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "obrelo@moveme.com", true, null, new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 186, 0, 0, 0, 186, 8, 3, 0, 0, 0, 46, 208, 167, 195, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 0, 72, 0, 0, 0, 72, 0, 70, 201, 107, 62, 0, 0, 3, 0, 80, 76, 84, 69, 255, 255, 255, 254, 254, 254, 74, 88, 95, 40, 183, 216, 122, 211, 231, 59, 190, 219, 54, 188, 219, 39, 183, 216, 73, 87, 94, 241, 250, 252, 127, 212, 232, 49, 186, 218, 185, 232, 242, 75, 89, 96, 189, 194, 196, 115, 126, 132, 36, 182, 215, 237, 239, 239, 244, 244, 245, 196, 201, 203, 170, 176, 179, 253, 254, 255, 91, 103, 109, 251, 251, 251, 253, 253, 254, 162, 169, 173, 79, 92, 99, 144, 152, 156, 34, 181, 215, 82, 95, 102, 219, 222, 224, 33, 181, 215, 250, 250, 251, 203, 238, 246, 40, 184, 216, 104, 116, 122, 227, 229, 230, 235, 249, 252, 87, 200, 225, 172, 228, 240, 124, 211, 232, 252, 252, 253, 76, 90, 97, 107, 119, 124, 247, 247, 248, 248, 248, 248, 38, 183, 216, 77, 91, 98, 148, 156, 160, 87, 100, 106, 89, 102, 108, 243, 244, 244, 126, 135, 141, 35, 182, 215, 215, 219, 220, 85, 99, 105, 241, 242, 242, 77, 90, 97, 81, 94, 101, 246, 252, 253, 182, 187, 190, 234, 236, 236, 223, 226, 227, 83, 96, 103, 140, 148, 153, 206, 209, 211, 102, 114, 120, 243, 251, 253, 225, 227, 229, 122, 132, 137, 137, 146, 151, 195, 200, 202, 92, 104, 111, 124, 134, 139, 80, 93, 100, 224, 227, 228, 109, 120, 126, 208, 211, 213, 154, 161, 165, 246, 246, 247, 193, 197, 200, 134, 143, 148, 143, 152, 157, 111, 122, 128, 176, 182, 185, 132, 142, 147, 100, 112, 118, 96, 108, 114, 98, 110, 117, 41, 184, 216, 241, 242, 243, 226, 228, 230, 30, 180, 214, 149, 157, 161, 168, 175, 178, 88, 101, 107, 237, 238, 239, 181, 186, 189, 214, 217, 219, 155, 162, 167, 79, 93, 100, 245, 245, 246, 252, 254, 254, 127, 137, 142, 232, 233, 234, 253, 254, 254, 37, 182, 216, 212, 216, 217, 50, 187, 218, 204, 208, 210, 34, 182, 215, 207, 211, 213, 254, 255, 255, 229, 231, 232, 146, 154, 158, 95, 107, 113, 222, 225, 226, 119, 129, 135, 235, 236, 237, 91, 104, 110, 172, 178, 182, 112, 123, 129, 250, 251, 251, 84, 97, 104, 161, 168, 172, 248, 249, 249, 236, 238, 238, 156, 164, 168, 166, 173, 176, 209, 213, 215, 184, 189, 192, 144, 153, 157, 139, 148, 152, 200, 205, 207, 93, 106, 112, 174, 180, 183, 187, 193, 195, 231, 232, 234, 158, 166, 170, 114, 125, 130, 151, 159, 163, 211, 215, 216, 240, 241, 241, 238, 250, 252, 186, 192, 194, 192, 235, 244, 226, 228, 229, 101, 113, 119, 218, 221, 222, 217, 220, 221, 253, 253, 253, 177, 183, 186, 233, 235, 236, 242, 243, 244, 78, 196, 223, 179, 185, 188, 135, 144, 149, 105, 116, 122, 80, 197, 224, 213, 241, 248, 111, 207, 229, 75, 195, 223, 97, 109, 115, 44, 185, 217, 245, 252, 253, 240, 250, 252, 152, 160, 164, 199, 203, 205, 128, 138, 143, 202, 206, 208, 165, 171, 175, 185, 190, 193, 106, 117, 123, 163, 225, 239, 249, 249, 250, 142, 151, 155, 248, 248, 249, 213, 216, 218, 130, 139, 144, 219, 221, 223, 121, 131, 136, 164, 171, 174, 117, 127, 133, 73, 195, 222, 248, 253, 254, 146, 219, 236, 131, 140, 145, 46, 186, 217, 169, 175, 179, 229, 230, 232, 147, 155, 159, 150, 158, 162, 140, 149, 154, 191, 196, 198, 193, 198, 201, 198, 202, 204, 57, 189, 219, 223, 245, 249, 238, 239, 240, 198, 237, 245, 99, 203, 227, 174, 228, 241, 118, 128, 133, 252, 252, 252, 232, 248, 251, 180, 230, 242, 167, 226, 239, 83, 198, 224, 136, 145, 150, 203, 207, 209, 221, 224, 225, 170, 177, 180, 192, 197, 199, 141, 218, 234, 68, 193, 221, 204, 238, 246, 175, 181, 184, 66, 192, 221, 61, 191, 220, 149, 220, 236, 156, 223, 237, 219, 243, 249, 37, 183, 216, 104, 205, 228, 190, 234, 243, 158, 223, 238, 239, 240, 241, 171, 227, 240, 187, 233, 243, 138, 216, 234, 220, 223, 224, 216, 242, 248, 183, 189, 192, 241, 250, 253, 93, 201, 226, 128, 213, 232, 226, 245, 250, 229, 247, 250, 221, 223, 224, 234, 248, 251, 90, 200, 226, 177, 230, 241, 95, 202, 226, 116, 209, 230, 207, 239, 246, 124, 212, 231, 182, 231, 242, 97, 203, 226, 200, 237, 245, 43, 185, 217, 252, 254, 255, 56, 189, 219, 210, 241, 247, 133, 214, 233, 205, 239, 246, 106, 206, 228, 25, 63, 96, 1, 0, 0, 12, 20, 73, 68, 65, 84, 120, 218, 237, 154, 121, 88, 19, 71, 31, 199, 217, 180, 21, 90, 27, 136, 88, 240, 53, 54, 213, 22, 250, 182, 37, 16, 110, 16, 240, 229, 16, 185, 35, 160, 220, 84, 228, 8, 8, 5, 4, 65, 46, 185, 65, 238, 75, 60, 8, 225, 6, 165, 104, 85, 180, 175, 241, 68, 69, 41, 138, 214, 104, 21, 60, 171, 182, 90, 180, 181, 247, 253, 246, 120, 239, 157, 217, 144, 108, 112, 145, 192, 75, 159, 36, 207, 59, 223, 191, 96, 103, 119, 230, 179, 51, 191, 107, 38, 171, 166, 134, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 164, 20, 210, 233, 62, 123, 243, 254, 243, 83, 210, 253, 155, 103, 187, 117, 20, 79, 190, 102, 211, 205, 99, 231, 111, 204, 154, 146, 110, 156, 63, 118, 115, 211, 26, 133, 163, 127, 247, 195, 247, 199, 67, 158, 154, 162, 66, 142, 127, 255, 195, 119, 138, 38, 191, 120, 183, 57, 241, 41, 245, 41, 235, 169, 196, 230, 187, 23, 21, 10, 190, 206, 238, 210, 175, 59, 212, 167, 165, 29, 191, 94, 178, 91, 167, 72, 67, 63, 251, 244, 51, 234, 211, 212, 51, 79, 159, 85, 164, 185, 31, 189, 223, 174, 62, 109, 181, 223, 63, 170, 64, 116, 231, 59, 31, 78, 31, 253, 195, 59, 206, 10, 68, 127, 246, 185, 219, 211, 71, 191, 253, 220, 179, 138, 68, 159, 190, 169, 3, 99, 71, 232, 8, 29, 161, 35, 244, 255, 39, 244, 120, 6, 181, 226, 149, 30, 157, 147, 196, 224, 188, 66, 33, 14, 67, 217, 209, 227, 23, 118, 61, 125, 247, 53, 10, 29, 251, 81, 201, 209, 25, 33, 93, 15, 58, 190, 121, 149, 66, 95, 111, 190, 119, 156, 161, 196, 232, 140, 29, 151, 123, 47, 78, 80, 204, 126, 241, 203, 141, 143, 25, 74, 139, 30, 255, 251, 229, 79, 156, 117, 38, 220, 198, 158, 223, 177, 80, 89, 209, 57, 140, 230, 222, 39, 85, 178, 175, 207, 82, 86, 244, 248, 85, 93, 15, 94, 93, 167, 138, 232, 140, 87, 186, 30, 124, 243, 196, 77, 155, 178, 162, 63, 201, 67, 149, 27, 61, 126, 199, 229, 79, 136, 115, 33, 231, 175, 59, 58, 62, 162, 116, 86, 229, 68, 231, 124, 220, 254, 201, 38, 226, 32, 239, 220, 177, 159, 58, 191, 122, 249, 237, 117, 42, 130, 254, 241, 170, 174, 15, 8, 15, 117, 222, 124, 36, 196, 210, 242, 149, 47, 55, 119, 171, 202, 172, 199, 127, 250, 8, 90, 203, 209, 142, 159, 142, 91, 226, 165, 214, 142, 159, 126, 83, 13, 244, 120, 198, 236, 31, 54, 17, 231, 27, 15, 111, 91, 90, 226, 246, 179, 234, 70, 239, 81, 149, 64, 183, 124, 241, 31, 98, 3, 217, 244, 154, 250, 42, 136, 62, 251, 152, 179, 74, 160, 51, 146, 18, 159, 39, 72, 223, 190, 116, 124, 33, 68, 63, 115, 71, 53, 208, 241, 68, 122, 231, 107, 226, 4, 245, 209, 247, 234, 16, 253, 252, 102, 149, 137, 48, 71, 94, 19, 91, 204, 47, 71, 56, 171, 86, 37, 29, 249, 224, 162, 138, 160, 115, 44, 213, 191, 36, 216, 215, 124, 247, 224, 111, 231, 127, 236, 252, 224, 236, 81, 149, 201, 166, 73, 33, 95, 94, 178, 131, 41, 212, 185, 227, 254, 195, 223, 40, 127, 112, 81, 214, 26, 38, 73, 189, 253, 220, 219, 58, 170, 88, 195, 224, 17, 50, 233, 204, 57, 59, 213, 68, 231, 48, 146, 238, 81, 165, 127, 85, 216, 106, 112, 44, 19, 59, 31, 118, 171, 36, 58, 110, 239, 179, 58, 239, 79, 248, 235, 150, 78, 119, 231, 108, 229, 69, 87, 79, 74, 252, 207, 203, 19, 237, 171, 237, 254, 121, 25, 100, 43, 165, 61, 135, 177, 252, 253, 199, 127, 59, 255, 93, 135, 66, 107, 190, 249, 87, 162, 165, 50, 31, 33, 113, 56, 33, 205, 199, 30, 190, 76, 161, 75, 175, 207, 10, 225, 40, 245, 193, 29, 135, 193, 185, 221, 254, 103, 10, 53, 159, 81, 254, 147, 222, 164, 23, 169, 101, 137, 206, 215, 17, 58, 66, 71, 232, 8, 29, 161, 255, 81, 114, 190, 254, 191, 124, 15, 115, 93, 145, 223, 195, 216, 189, 223, 53, 125, 244, 174, 247, 237, 20, 136, 190, 166, 227, 94, 226, 116, 201, 19, 239, 117, 40, 242, 219, 47, 157, 47, 238, 182, 135, 76, 143, 60, 164, 253, 238, 23, 10, 253, 194, 116, 221, 71, 95, 77, 115, 218, 19, 191, 250, 72, 145, 223, 10, 130, 51, 233, 159, 175, 31, 153, 198, 188, 135, 28, 185, 254, 243, 81, 53, 5, 171, 251, 81, 111, 103, 243, 153, 217, 83, 210, 153, 230, 206, 222, 71, 221, 106, 10, 215, 154, 77, 231, 122, 63, 125, 110, 74, 250, 180, 247, 156, 18, 124, 141, 140, 132, 132, 132, 132, 132, 132, 244, 36, 237, 11, 21, 108, 177, 79, 195, 181, 37, 174, 110, 31, 38, 211, 196, 215, 126, 19, 87, 165, 57, 54, 19, 227, 136, 66, 65, 103, 130, 152, 153, 226, 198, 248, 243, 236, 53, 121, 30, 27, 184, 108, 54, 215, 195, 164, 222, 62, 143, 79, 198, 244, 73, 182, 192, 149, 90, 186, 111, 38, 134, 90, 236, 11, 58, 227, 37, 204, 20, 249, 156, 129, 211, 108, 119, 83, 150, 39, 147, 201, 140, 102, 89, 187, 115, 247, 251, 142, 146, 216, 181, 175, 177, 112, 113, 151, 24, 205, 196, 88, 67, 229, 160, 51, 151, 157, 51, 67, 62, 180, 51, 140, 107, 102, 172, 33, 149, 177, 174, 95, 88, 233, 168, 20, 93, 19, 92, 92, 26, 57, 35, 232, 115, 94, 0, 157, 105, 205, 157, 145, 41, 23, 68, 198, 154, 105, 140, 87, 248, 174, 200, 148, 113, 232, 75, 148, 13, 93, 52, 199, 159, 107, 160, 241, 184, 232, 236, 171, 249, 34, 165, 70, 199, 134, 246, 100, 18, 172, 52, 27, 79, 150, 131, 131, 3, 203, 211, 152, 70, 92, 40, 243, 31, 194, 148, 25, 221, 124, 112, 189, 13, 65, 106, 230, 178, 251, 61, 167, 34, 39, 223, 171, 7, 220, 137, 11, 54, 153, 110, 77, 74, 140, 142, 21, 245, 209, 225, 148, 135, 187, 22, 71, 85, 134, 198, 24, 198, 132, 198, 53, 212, 159, 46, 131, 19, 79, 247, 88, 142, 201, 162, 139, 204, 227, 236, 245, 5, 230, 124, 202, 174, 242, 4, 203, 188, 82, 34, 242, 40, 163, 63, 230, 243, 102, 109, 209, 22, 159, 137, 208, 243, 230, 232, 219, 235, 103, 248, 76, 9, 61, 99, 53, 244, 80, 227, 237, 188, 228, 197, 146, 139, 161, 181, 243, 3, 153, 224, 178, 195, 238, 56, 18, 250, 231, 149, 69, 123, 14, 133, 45, 72, 61, 53, 127, 201, 59, 130, 69, 227, 58, 10, 109, 24, 200, 242, 222, 184, 210, 132, 151, 53, 208, 64, 74, 55, 88, 220, 182, 168, 168, 168, 17, 175, 225, 213, 169, 43, 2, 252, 79, 82, 161, 139, 234, 18, 174, 101, 21, 164, 46, 72, 245, 94, 173, 153, 16, 49, 79, 238, 73, 47, 181, 0, 29, 25, 4, 123, 159, 204, 38, 187, 174, 32, 55, 16, 6, 75, 23, 55, 76, 130, 30, 60, 255, 150, 171, 158, 3, 248, 43, 122, 187, 71, 86, 66, 157, 204, 172, 233, 107, 166, 18, 241, 213, 192, 148, 219, 239, 155, 34, 73, 94, 252, 61, 61, 251, 247, 47, 240, 174, 178, 176, 198, 219, 92, 173, 40, 208, 181, 133, 159, 59, 138, 31, 181, 214, 115, 140, 140, 170, 147, 19, 125, 81, 46, 180, 107, 179, 211, 67, 178, 54, 240, 86, 140, 9, 108, 48, 173, 218, 39, 65, 103, 45, 117, 160, 75, 226, 15, 51, 214, 87, 186, 188, 88, 246, 72, 88, 16, 41, 54, 149, 85, 109, 25, 155, 188, 236, 43, 166, 210, 6, 71, 225, 227, 232, 70, 78, 142, 158, 52, 233, 45, 214, 125, 190, 62, 242, 213, 27, 91, 8, 75, 247, 24, 30, 111, 189, 152, 213, 46, 232, 2, 1, 35, 18, 116, 154, 1, 105, 8, 26, 147, 155, 37, 45, 127, 236, 45, 194, 233, 228, 184, 202, 58, 29, 37, 110, 154, 183, 95, 247, 137, 232, 252, 200, 106, 50, 57, 222, 47, 123, 117, 158, 92, 236, 131, 90, 112, 210, 115, 155, 30, 107, 241, 217, 189, 30, 14, 49, 32, 65, 31, 39, 219, 13, 110, 218, 98, 243, 18, 6, 152, 210, 101, 27, 117, 171, 236, 197, 232, 11, 158, 136, 206, 175, 79, 103, 141, 235, 215, 115, 239, 173, 57, 242, 160, 151, 183, 129, 187, 15, 251, 82, 52, 205, 117, 1, 77, 91, 11, 101, 208, 51, 47, 184, 166, 94, 209, 34, 18, 129, 131, 139, 144, 240, 85, 253, 194, 28, 48, 113, 244, 160, 216, 254, 30, 147, 190, 237, 208, 193, 247, 150, 27, 202, 160, 27, 175, 183, 216, 88, 115, 45, 98, 28, 186, 97, 148, 71, 14, 97, 98, 233, 174, 169, 37, 46, 193, 48, 76, 51, 217, 59, 155, 228, 64, 231, 65, 19, 93, 96, 69, 209, 36, 236, 7, 77, 238, 97, 36, 116, 186, 158, 137, 102, 131, 126, 84, 69, 24, 219, 134, 6, 12, 168, 49, 3, 250, 203, 53, 63, 184, 10, 236, 170, 225, 148, 252, 148, 228, 220, 13, 182, 192, 229, 250, 210, 200, 232, 244, 165, 53, 165, 203, 50, 98, 48, 89, 116, 44, 165, 6, 120, 47, 45, 167, 154, 55, 96, 165, 47, 116, 203, 61, 152, 67, 39, 120, 228, 48, 25, 199, 112, 112, 107, 110, 37, 69, 147, 96, 62, 152, 74, 211, 211, 82, 116, 122, 89, 11, 100, 85, 139, 216, 179, 29, 198, 159, 216, 34, 48, 68, 28, 15, 212, 17, 198, 236, 22, 98, 158, 243, 34, 185, 224, 65, 118, 36, 25, 221, 218, 187, 146, 34, 37, 25, 173, 53, 51, 0, 230, 125, 112, 39, 97, 122, 62, 9, 46, 214, 224, 89, 221, 37, 114, 148, 215, 174, 208, 255, 79, 68, 80, 52, 213, 93, 5, 43, 207, 58, 32, 146, 160, 231, 52, 10, 136, 217, 192, 70, 27, 225, 106, 101, 86, 128, 33, 220, 160, 101, 233, 189, 32, 222, 159, 172, 203, 207, 2, 15, 134, 59, 138, 48, 41, 122, 108, 41, 159, 2, 253, 100, 33, 0, 53, 14, 44, 138, 17, 247, 155, 151, 230, 1, 150, 140, 118, 202, 75, 94, 244, 23, 168, 252, 162, 46, 43, 26, 152, 193, 46, 9, 186, 109, 181, 36, 228, 137, 50, 224, 16, 198, 133, 249, 248, 63, 87, 183, 130, 214, 131, 245, 47, 137, 37, 44, 215, 197, 137, 152, 23, 70, 69, 82, 244, 42, 125, 170, 66, 32, 161, 21, 252, 25, 84, 56, 244, 39, 73, 66, 190, 197, 134, 17, 111, 112, 114, 244, 18, 104, 48, 187, 5, 20, 77, 249, 133, 192, 14, 172, 175, 96, 99, 232, 153, 38, 218, 210, 216, 233, 13, 227, 79, 13, 30, 71, 22, 121, 195, 124, 188, 221, 98, 133, 88, 173, 48, 104, 208, 218, 188, 246, 141, 161, 211, 28, 138, 205, 41, 208, 177, 157, 27, 128, 25, 110, 136, 34, 153, 135, 85, 0, 176, 246, 182, 198, 201, 209, 137, 196, 83, 51, 66, 209, 180, 204, 27, 70, 185, 84, 137, 173, 111, 109, 52, 148, 182, 70, 114, 97, 180, 195, 183, 105, 230, 251, 89, 26, 84, 10, 172, 245, 145, 160, 103, 14, 206, 163, 64, 231, 107, 2, 179, 139, 182, 104, 34, 37, 149, 166, 30, 79, 252, 218, 250, 194, 201, 209, 11, 225, 98, 31, 24, 166, 104, 114, 10, 128, 171, 89, 32, 65, 103, 207, 205, 147, 182, 238, 76, 7, 151, 2, 156, 212, 176, 136, 86, 99, 74, 244, 224, 225, 152, 49, 116, 122, 16, 41, 229, 145, 208, 247, 128, 53, 183, 46, 33, 167, 67, 254, 110, 107, 57, 209, 53, 55, 192, 197, 246, 167, 10, 249, 193, 160, 137, 219, 34, 65, 231, 146, 183, 213, 82, 116, 65, 128, 1, 53, 122, 178, 100, 214, 233, 122, 78, 19, 163, 155, 245, 203, 28, 62, 20, 154, 201, 137, 110, 229, 1, 147, 64, 201, 227, 22, 99, 239, 10, 83, 75, 108, 148, 4, 93, 175, 158, 84, 175, 23, 195, 88, 94, 82, 139, 27, 140, 43, 72, 36, 14, 30, 243, 199, 201, 63, 95, 36, 69, 79, 166, 170, 215, 249, 245, 32, 183, 229, 180, 26, 145, 162, 184, 57, 207, 22, 122, 238, 228, 232, 117, 97, 214, 208, 140, 15, 105, 143, 63, 121, 217, 189, 148, 136, 199, 139, 37, 232, 101, 60, 169, 155, 170, 29, 10, 4, 151, 250, 95, 194, 221, 180, 31, 84, 147, 172, 154, 52, 125, 89, 197, 101, 99, 82, 244, 229, 84, 232, 152, 27, 24, 195, 230, 130, 215, 60, 242, 140, 1, 55, 221, 43, 135, 155, 98, 197, 208, 98, 152, 126, 3, 163, 100, 139, 123, 99, 72, 211, 15, 132, 70, 141, 234, 10, 105, 209, 203, 186, 160, 63, 54, 6, 191, 110, 5, 120, 101, 122, 46, 94, 206, 243, 15, 1, 103, 51, 112, 252, 150, 84, 255, 56, 109, 11, 85, 35, 213, 48, 19, 160, 171, 37, 195, 138, 59, 184, 133, 84, 223, 87, 84, 19, 181, 182, 28, 149, 192, 200, 41, 104, 23, 182, 126, 239, 197, 73, 157, 208, 168, 114, 128, 237, 9, 95, 137, 103, 47, 221, 106, 208, 194, 63, 207, 23, 167, 142, 38, 55, 56, 233, 166, 75, 128, 57, 107, 30, 134, 27, 145, 67, 77, 99, 11, 231, 83, 123, 120, 193, 224, 144, 104, 114, 116, 175, 2, 144, 146, 28, 14, 126, 54, 230, 68, 162, 252, 18, 144, 104, 104, 27, 183, 201, 129, 206, 247, 93, 74, 20, 155, 186, 5, 194, 177, 121, 231, 55, 240, 204, 136, 66, 84, 111, 144, 47, 69, 215, 48, 216, 187, 150, 168, 183, 222, 77, 88, 10, 95, 248, 176, 19, 124, 251, 149, 176, 181, 77, 83, 252, 238, 252, 132, 3, 116, 141, 182, 19, 163, 147, 163, 107, 187, 193, 29, 60, 179, 223, 126, 108, 139, 239, 13, 131, 53, 211, 63, 79, 158, 218, 49, 229, 4, 19, 98, 26, 152, 105, 153, 180, 172, 21, 218, 111, 27, 110, 233, 175, 54, 131, 65, 131, 22, 221, 40, 32, 109, 171, 241, 255, 211, 179, 132, 70, 162, 166, 109, 229, 135, 163, 225, 51, 229, 176, 217, 176, 5, 166, 39, 102, 96, 191, 155, 125, 254, 80, 134, 211, 161, 116, 188, 26, 140, 214, 171, 226, 79, 138, 206, 79, 139, 133, 217, 203, 116, 87, 228, 50, 67, 81, 83, 90, 69, 73, 38, 172, 29, 91, 107, 229, 170, 216, 243, 94, 34, 60, 21, 47, 148, 221, 217, 233, 22, 187, 44, 210, 217, 238, 209, 226, 133, 168, 241, 202, 38, 163, 227, 107, 171, 215, 215, 83, 144, 186, 171, 205, 22, 26, 153, 150, 21, 92, 104, 108, 155, 9, 81, 157, 185, 87, 247, 149, 56, 174, 56, 24, 8, 83, 20, 59, 18, 155, 20, 93, 173, 201, 77, 15, 38, 5, 107, 118, 95, 106, 65, 234, 1, 63, 184, 216, 54, 65, 190, 114, 110, 242, 140, 26, 28, 203, 232, 84, 71, 72, 219, 77, 190, 205, 83, 147, 69, 199, 251, 205, 49, 245, 36, 238, 182, 245, 43, 22, 251, 98, 204, 176, 22, 83, 252, 140, 241, 88, 122, 42, 235, 209, 159, 220, 96, 112, 119, 207, 13, 164, 139, 119, 71, 166, 182, 196, 95, 54, 65, 85, 113, 242, 30, 41, 99, 13, 253, 193, 158, 143, 145, 179, 182, 122, 167, 201, 30, 220, 105, 208, 100, 54, 51, 126, 171, 125, 222, 146, 28, 222, 86, 231, 200, 188, 61, 77, 119, 99, 145, 28, 17, 6, 84, 236, 61, 193, 76, 217, 77, 210, 214, 212, 184, 236, 41, 156, 104, 248, 195, 189, 3, 105, 104, 186, 141, 86, 125, 221, 184, 227, 82, 3, 7, 233, 77, 52, 3, 174, 63, 233, 212, 68, 180, 246, 128, 41, 157, 212, 200, 234, 25, 153, 48, 56, 70, 200, 110, 171, 51, 202, 245, 72, 123, 94, 154, 1, 251, 196, 232, 84, 142, 241, 113, 207, 203, 210, 34, 109, 47, 233, 186, 30, 229, 223, 106, 243, 199, 161, 175, 239, 247, 230, 218, 138, 207, 3, 218, 120, 201, 77, 164, 17, 48, 195, 180, 91, 46, 225, 98, 2, 155, 96, 199, 129, 202, 177, 112, 151, 13, 202, 106, 122, 144, 19, 105, 11, 83, 40, 131, 142, 159, 194, 228, 250, 57, 136, 193, 109, 245, 170, 150, 47, 126, 99, 106, 135, 96, 139, 226, 150, 239, 201, 117, 77, 223, 27, 24, 28, 200, 62, 232, 154, 91, 145, 32, 32, 47, 154, 81, 212, 74, 92, 185, 78, 246, 165, 89, 167, 86, 184, 88, 92, 169, 185, 58, 188, 108, 220, 175, 18, 139, 4, 69, 21, 243, 77, 90, 45, 92, 90, 77, 86, 251, 10, 235, 68, 146, 228, 86, 236, 189, 114, 229, 198, 42, 210, 214, 65, 251, 29, 208, 217, 85, 105, 233, 97, 164, 239, 228, 207, 43, 137, 117, 233, 219, 95, 208, 242, 206, 155, 83, 59, 1, 19, 59, 219, 201, 34, 183, 226, 198, 198, 150, 98, 183, 162, 148, 113, 207, 243, 235, 172, 112, 165, 53, 97, 243, 34, 62, 75, 158, 91, 90, 52, 18, 65, 177, 166, 124, 163, 56, 225, 242, 210, 193, 229, 194, 191, 188, 75, 118, 164, 74, 33, 254, 232, 8, 233, 69, 69, 17, 160, 179, 101, 218, 228, 155, 234, 188, 106, 75, 231, 58, 253, 117, 203, 204, 252, 228, 131, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 132, 244, 135, 235, 191, 228, 32, 9, 183, 243, 62, 30, 230, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, null, false, null, "OBRELO@MOVEME.COM", "OBRELO@MOVEME.COM", "AQAAAAEAACcQAAAAEHdIyFpzmTwqHaZ0iUT/RQ9Z0n8hBkCCGF6nlRPuIKyCMJndBISzNRLmtL5wdxNkPA==", null, false, "", false, 0, "obrelo@moveme.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 4, 3 },
                    { 5, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "RequestId", "AdditionalInformation", "ClientId", "Created", "Date", "DeliveryAddress", "Inactive", "Price", "Rooms", "StatusId", "TotalWeightApprox", "TransportDistanceApprox" },
                values: new object[,]
                {
                    { 1, "No additional information", 5, new DateTime(2021, 1, 16, 11, 49, 10, 54, DateTimeKind.Local).AddTicks(7975), new DateTime(2021, 2, 15, 11, 49, 10, 59, DateTimeKind.Local).AddTicks(9198), 6, false, 700.0, 5, 1, 100, 250 },
                    { 2, "No additional information", 5, new DateTime(2021, 1, 16, 11, 49, 10, 60, DateTimeKind.Local).AddTicks(6062), new DateTime(2021, 3, 7, 11, 49, 10, 60, DateTimeKind.Local).AddTicks(6121), 7, false, 336.0, 3, 1, 150, 200 },
                    { 3, "No additional information", 5, new DateTime(2021, 1, 16, 11, 49, 10, 60, DateTimeKind.Local).AddTicks(6309), new DateTime(2021, 2, 25, 11, 49, 10, 60, DateTimeKind.Local).AddTicks(6316), 8, false, 616.0, 5, 3, 150, 220 }
                });

            migrationBuilder.InsertData(
                table: "Offer",
                columns: new[] { "OfferId", "CreatedAt", "OfferStatusId", "RequestId", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 1, 16, 11, 49, 10, 61, DateTimeKind.Local).AddTicks(1587), 1, 1, 3 },
                    { 3, new DateTime(2021, 1, 16, 11, 49, 10, 61, DateTimeKind.Local).AddTicks(1689), 1, 1, 4 },
                    { 4, new DateTime(2021, 1, 16, 11, 49, 10, 61, DateTimeKind.Local).AddTicks(1722), 1, 2, 4 },
                    { 1, new DateTime(2021, 1, 16, 11, 49, 10, 60, DateTimeKind.Local).AddTicks(8204), 4, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "RatingId", "CreatedAt", "Description", "RatingTypeId", "RequestId", "SupplierId" },
                values: new object[] { 1, new DateTime(2021, 1, 16, 11, 49, 10, 61, DateTimeKind.Local).AddTicks(2980), "Professionalism at the highest level!", 1, 3, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_NotificationTypeId",
                table: "Notification",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserFromId",
                table: "Notification",
                column: "UserFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserToId",
                table: "Notification",
                column: "UserToId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_OfferStatusId",
                table: "Offer",
                column: "OfferStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_RequestId",
                table: "Offer",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_UserId",
                table: "Offer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_RatingTypeId",
                table: "Rating",
                column: "RatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_RequestId",
                table: "Rating",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_SupplierId",
                table: "Rating",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ClientId",
                table: "Request",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_DeliveryAddress",
                table: "Request",
                column: "DeliveryAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Request_StatusId",
                table: "Request",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "NotificationType");

            migrationBuilder.DropTable(
                name: "OfferStatus");

            migrationBuilder.DropTable(
                name: "RatingType");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
