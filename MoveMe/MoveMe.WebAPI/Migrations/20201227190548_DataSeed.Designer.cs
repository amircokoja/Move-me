﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoveMe.WebAPI.Database;

namespace MoveMe.WebAPI.Migrations
{
    [DbContext(typeof(MoveMeContext))]
    [Migration("20201227190548_DataSeed")]
    partial class DataSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "7f699a8b-61c7-44ab-8a26-e65ae1d9b92c",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "9a85fe27-1c21-418b-93e9-7281f08d7340",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "98e5f7c6-8be8-4df3-a895-ba3cf39d5a7b",
                            Name = "Supplier",
                            NormalizedName = "SUPPLIER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalAddress")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("AddressId");

                    b.HasIndex("CountryId");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            CountryId = 1
                        });
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.HasKey("CountryId");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "Albania"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "Austria"
                        },
                        new
                        {
                            CountryId = 3,
                            Name = "Belgium"
                        },
                        new
                        {
                            CountryId = 4,
                            Name = "Bosnia and Herzegovina"
                        },
                        new
                        {
                            CountryId = 5,
                            Name = "Croatia"
                        },
                        new
                        {
                            CountryId = 6,
                            Name = "Denmark"
                        },
                        new
                        {
                            CountryId = 7,
                            Name = "Finland"
                        },
                        new
                        {
                            CountryId = 8,
                            Name = "France"
                        },
                        new
                        {
                            CountryId = 9,
                            Name = "Germany"
                        },
                        new
                        {
                            CountryId = 10,
                            Name = "Greece"
                        },
                        new
                        {
                            CountryId = 11,
                            Name = "Hungary"
                        },
                        new
                        {
                            CountryId = 12,
                            Name = "Iceland"
                        },
                        new
                        {
                            CountryId = 13,
                            Name = "Ireland"
                        },
                        new
                        {
                            CountryId = 14,
                            Name = "Italy"
                        },
                        new
                        {
                            CountryId = 15,
                            Name = "Luxembourg"
                        },
                        new
                        {
                            CountryId = 16,
                            Name = "Montenegro"
                        },
                        new
                        {
                            CountryId = 17,
                            Name = "Netherlands"
                        },
                        new
                        {
                            CountryId = 18,
                            Name = "Norway"
                        },
                        new
                        {
                            CountryId = 19,
                            Name = "Poland"
                        },
                        new
                        {
                            CountryId = 20,
                            Name = "Portugal"
                        },
                        new
                        {
                            CountryId = 21,
                            Name = "Russia"
                        },
                        new
                        {
                            CountryId = 22,
                            Name = "Serbia"
                        },
                        new
                        {
                            CountryId = 23,
                            Name = "Slovenia"
                        },
                        new
                        {
                            CountryId = 24,
                            Name = "Spain"
                        },
                        new
                        {
                            CountryId = 25,
                            Name = "Sweden"
                        },
                        new
                        {
                            CountryId = 26,
                            Name = "Switzerland"
                        },
                        new
                        {
                            CountryId = 27,
                            Name = "Turkey"
                        },
                        new
                        {
                            CountryId = 28,
                            Name = "Ukraine"
                        },
                        new
                        {
                            CountryId = 29,
                            Name = "United Kingdom"
                        });
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("NotificationTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserFromId")
                        .HasColumnType("int");

                    b.Property<int>("UserToId")
                        .HasColumnType("int");

                    b.HasKey("NotificationId");

                    b.HasIndex("NotificationTypeId");

                    b.HasIndex("UserFromId");

                    b.HasIndex("UserToId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.NotificationType", b =>
                {
                    b.Property<int>("NotificationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationTypeId");

                    b.ToTable("NotificationType");

                    b.HasData(
                        new
                        {
                            NotificationTypeId = 1,
                            Type = "New request"
                        },
                        new
                        {
                            NotificationTypeId = 2,
                            Type = "Offer accepted"
                        },
                        new
                        {
                            NotificationTypeId = 3,
                            Type = "Offer rejected"
                        },
                        new
                        {
                            NotificationTypeId = 4,
                            Type = "Offer finished"
                        },
                        new
                        {
                            NotificationTypeId = 5,
                            Type = "Feedback"
                        });
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Offer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OfferStatusId")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OfferId");

                    b.HasIndex("OfferStatusId");

                    b.HasIndex("RequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.OfferStatus", b =>
                {
                    b.Property<int>("OfferStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfferStatusId");

                    b.ToTable("OfferStatus");

                    b.HasData(
                        new
                        {
                            OfferStatusId = 1,
                            Name = "Active"
                        },
                        new
                        {
                            OfferStatusId = 2,
                            Name = "Accepted"
                        },
                        new
                        {
                            OfferStatusId = 3,
                            Name = "Rejected"
                        },
                        new
                        {
                            OfferStatusId = 4,
                            Name = "Finished"
                        });
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int?>("RatingTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("RatingTypeId");

                    b.HasIndex("RequestId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.RatingType", b =>
                {
                    b.Property<int>("RatingTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("RatingTypeId");

                    b.ToTable("RatingType");

                    b.HasData(
                        new
                        {
                            RatingTypeId = 1,
                            Type = "Positive"
                        },
                        new
                        {
                            RatingTypeId = 2,
                            Type = "Neutral"
                        },
                        new
                        {
                            RatingTypeId = 3,
                            Type = "Negative"
                        });
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("DeliveryAddress")
                        .HasColumnType("int");

                    b.Property<bool>("Inactive")
                        .HasColumnType("bit");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("Rooms")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("TotalWeightApprox")
                        .HasColumnType("int");

                    b.Property<int>("TransportDistanceApprox")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeliveryAddress");

                    b.HasIndex("StatusId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("StatusId");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Name = "Pending"
                        },
                        new
                        {
                            StatusId = 2,
                            Name = "Accepted"
                        },
                        new
                        {
                            StatusId = 3,
                            Name = "Finished"
                        });
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Active = true,
                            AddressId = 1,
                            ConcurrencyStamp = "0a89bb40-6e47-4949-a2fc-df507d94c9cd",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJjWIMbKsdkW0mc20V5KesgmPstsAbxSRskxuRxATx4isVFLd75OnfAOvkIKwkX4MQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserId = 0,
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("MoveMe.WebAPI.Database.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("MoveMe.WebAPI.Database.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoveMe.WebAPI.Database.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("MoveMe.WebAPI.Database.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Address", b =>
                {
                    b.HasOne("MoveMe.WebAPI.Database.Country", "Country")
                        .WithMany("Address")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK__Address__Country__267ABA7A");
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Notification", b =>
                {
                    b.HasOne("MoveMe.WebAPI.Database.NotificationType", "NotificationType")
                        .WithMany()
                        .HasForeignKey("NotificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoveMe.WebAPI.Database.User", "UserFrom")
                        .WithMany()
                        .HasForeignKey("UserFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoveMe.WebAPI.Database.User", "UserTo")
                        .WithMany()
                        .HasForeignKey("UserToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Offer", b =>
                {
                    b.HasOne("MoveMe.WebAPI.Database.OfferStatus", "OfferStatus")
                        .WithMany()
                        .HasForeignKey("OfferStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoveMe.WebAPI.Database.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoveMe.WebAPI.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Rating", b =>
                {
                    b.HasOne("MoveMe.WebAPI.Database.RatingType", "RatingType")
                        .WithMany("Rating")
                        .HasForeignKey("RatingTypeId")
                        .HasConstraintName("FK__Rating__RatingTy__37A5467C");

                    b.HasOne("MoveMe.WebAPI.Database.Request", "Request")
                        .WithMany("Rating")
                        .HasForeignKey("RequestId")
                        .HasConstraintName("FK__Rating__RequestI__36B12243");

                    b.HasOne("MoveMe.WebAPI.Database.User", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.Request", b =>
                {
                    b.HasOne("MoveMe.WebAPI.Database.User", "Client")
                        .WithMany("Request")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK__Request__ClientI__2F10007B");

                    b.HasOne("MoveMe.WebAPI.Database.Address", "DeliveryAddressNavigation")
                        .WithMany("Request")
                        .HasForeignKey("DeliveryAddress")
                        .HasConstraintName("FK__Request__Deliver__300424B4");

                    b.HasOne("MoveMe.WebAPI.Database.Status", "Status")
                        .WithMany("Request")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK__Request__StatusI__30F848ED");
                });

            modelBuilder.Entity("MoveMe.WebAPI.Database.User", b =>
                {
                    b.HasOne("MoveMe.WebAPI.Database.Address", "Address")
                        .WithMany("User")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK__User__AddressId__29572725");
                });
#pragma warning restore 612, 618
        }
    }
}