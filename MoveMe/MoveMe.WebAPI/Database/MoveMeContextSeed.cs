using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace MoveMe.WebAPI.Database
{
    public partial class MoveMeContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "Albania" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "Austria" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, Name = "Belgium" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 4, Name = "Bosnia and Herzegovina" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 5, Name = "Croatia" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 6, Name = "Denmark" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 7, Name = "Finland" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 8, Name = "France" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 9, Name = "Germany" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 10, Name = "Greece" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 11, Name = "Hungary" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 12, Name = "Iceland" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 13, Name = "Ireland" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 14, Name = "Italy" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 15, Name = "Luxembourg" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 16, Name = "Montenegro" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 17, Name = "Netherlands" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 18, Name = "Norway" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 19, Name = "Poland" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 20, Name = "Portugal" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 21, Name = "Russia" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 22, Name = "Serbia" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 23, Name = "Slovenia" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 24, Name = "Spain" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 25, Name = "Sweden" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 26, Name = "Switzerland" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 27, Name = "Turkey" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 28, Name = "Ukraine" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 29, Name = "United Kingdom" });

            modelBuilder.Entity<OfferStatus>().HasData(new OfferStatus { OfferStatusId = 1, Name = "Active" });
            modelBuilder.Entity<OfferStatus>().HasData(new OfferStatus { OfferStatusId = 2, Name = "Accepted" });
            modelBuilder.Entity<OfferStatus>().HasData(new OfferStatus { OfferStatusId = 3, Name = "Rejected" });
            modelBuilder.Entity<OfferStatus>().HasData(new OfferStatus { OfferStatusId = 4, Name = "Finished" });

            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 1, Name = "Pending" });
            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 2, Name = "Accepted" });
            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 3, Name = "Finished" });

            modelBuilder.Entity<RatingType>().HasData(new RatingType { RatingTypeId = 1, Type = "Positive" });
            modelBuilder.Entity<RatingType>().HasData(new RatingType { RatingTypeId = 2, Type = "Neutral" });
            modelBuilder.Entity<RatingType>().HasData(new RatingType { RatingTypeId = 3, Type = "Negative" });

            modelBuilder.Entity<Address>().HasData(new Address { AddressId = 1, CountryId = 1, City = "Admin", Street = "Admin", ZipCode = "10000", AdditionalAddress = "Admin" });
            modelBuilder.Entity<Address>().HasData(new Address { AddressId = 2, CountryId = 4, City = "Mostar", Street = "Brace fejica", ZipCode = "88000", AdditionalAddress = "No additional address" });
            modelBuilder.Entity<Address>().HasData(new Address { AddressId = 3, CountryId = 5, City = "Zagreb", Street = "Rusanova ulica 3", ZipCode = "10000", AdditionalAddress = "No additional address" });
            modelBuilder.Entity<Address>().HasData(new Address { AddressId = 4, CountryId = 4, City = "Sarajevo", Street = "Grbavica", ZipCode = "71000", AdditionalAddress = "Trg heroja" });
            modelBuilder.Entity<Address>().HasData(new Address { AddressId = 5, CountryId = 4, City = "Konjic", Street = "Omladinska 3", ZipCode = "88400", AdditionalAddress = "No additional address" });
            modelBuilder.Entity<Address>().HasData(new Address { AddressId = 6, CountryId = 4, City = "Makarska", Street = "Gorinka", ZipCode = "21300", AdditionalAddress = "No additional address" });
            modelBuilder.Entity<Address>().HasData(new Address { AddressId = 7, CountryId = 5, City = "Split", Street = "Sibenska ulica 28", ZipCode = "21000", AdditionalAddress = "No additional address" });
            modelBuilder.Entity<Address>().HasData(new Address { AddressId = 8, CountryId = 4, City = "Zenica", Street = "Aleja sehida", ZipCode = "72000", AdditionalAddress = "No additional address" });

            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 2, Name = "Client", NormalizedName = "CLIENT" });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 3, Name = "Supplier", NormalizedName = "SUPPLIER" });


            modelBuilder.Entity<User>().HasData(new User { Id = 1, Active = true, AddressId = 1, FirstName = "Admin", LastName = "Admin", UserName = "admin@admin.com", NormalizedUserName = "admin@admin.com".ToUpper(),
            Email = "admin@admin.com", NormalizedEmail = "admin@admin.com".ToUpper(), EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "qweasd"), SecurityStamp = string.Empty });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { RoleId = 1, UserId = 1 });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Active = true,
                AddressId = 2,
                FirstName = "Chris",
                LastName = "Simanek",
                UserName = "chris.simanek@moveme.com",
                NormalizedUserName = "chris.simanek@moveme.com".ToUpper(),
                Email = "chris.simanek@moveme.com",
                NormalizedEmail = "chris.simanek@moveme.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "qweasd"),
                SecurityStamp = string.Empty
            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { RoleId = 2, UserId = 2 });


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                Active = true,
                AddressId = 3,
                Company = "Obrelo",
                Image = System.Convert.FromBase64String(
                    "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"),
                UserName = "obrelo@moveme.com",
                Email = "obrelo@moveme.com",
                NormalizedUserName = "obrelo@moveme.com".ToUpper(),
                EmailConfirmed = true,
                NormalizedEmail = "obrelo@moveme.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "qweasd"),
                SecurityStamp = string.Empty
            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { RoleId = 3, UserId = 3 });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 4,
                Active = true,
                AddressId = 4,
                Company = "CityS",
                Image = System.Convert.FromBase64String(
                  "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"),
                UserName = "citys@moveme.com",
                NormalizedUserName = "citys@moveme.com".ToUpper(),
                Email = "citys@moveme.com",
                NormalizedEmail = "citys@moveme.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "qweasd"),
                SecurityStamp = string.Empty
            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { RoleId = 3, UserId = 4 });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 5,
                Active = true,
                AddressId = 5,
                FirstName = "Albie",
                LastName = "Boyle",
                UserName = "albie.boyle@moveme.com",
                NormalizedUserName = "albie.boyle@moveme.com".ToUpper(),
                Email = "albie.boyle@moveme.com",
                NormalizedEmail = "albie.boyle@moveme.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "qweasd"),
                SecurityStamp = string.Empty
            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { RoleId = 2, UserId = 5 });


            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { NotificationTypeId = 1, Type = "New request" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { NotificationTypeId = 2, Type = "Offer accepted" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { NotificationTypeId = 3, Type = "Offer rejected" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { NotificationTypeId = 4, Type = "Offer finished" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { NotificationTypeId = 5, Type = "Feedback" });

            modelBuilder.Entity<Request>().HasData(new Request
            {
                RequestId = 1,
                AdditionalInformation = "No additional information",
                ClientId = 5,
                Created = DateTime.Now,
                Date = DateTime.Now.AddDays(30),
                DeliveryAddress = 6,
                Price = 700,
                Rooms = 5,
                StatusId = 1,
                TotalWeightApprox = 100,
                TransportDistanceApprox = 250
            });

            modelBuilder.Entity<Request>().HasData(new Request
            {
                RequestId = 2,
                AdditionalInformation = "No additional information",
                ClientId = 5,
                Created = DateTime.Now,
                Date = DateTime.Now.AddDays(50),
                DeliveryAddress = 7,
                Price = 336,
                Rooms = 3,
                StatusId = 1,
                TotalWeightApprox = 150,
                TransportDistanceApprox = 200
            });

            modelBuilder.Entity<Request>().HasData(new Request
            {
                RequestId = 3,
                AdditionalInformation = "No additional information",
                ClientId = 5,
                Created = DateTime.Now,
                Date = DateTime.Now.AddDays(40),
                DeliveryAddress = 8,
                Price = 616,
                Rooms = 5,
                StatusId = 3,
                TotalWeightApprox = 150,
                TransportDistanceApprox = 220
            });

            modelBuilder.Entity<Offer>().HasData(new Offer
            {
                OfferId = 1,
                CreatedAt = DateTime.Now,
                OfferStatusId = 4,
                RequestId = 3,
                UserId = 3
            });

            modelBuilder.Entity<Offer>().HasData(new Offer
            {
                OfferId = 2,
                CreatedAt = DateTime.Now,
                OfferStatusId = 1,
                RequestId = 1,
                UserId = 3
            });

            modelBuilder.Entity<Offer>().HasData(new Offer
            {
                OfferId = 3,
                CreatedAt = DateTime.Now,
                OfferStatusId = 1,
                RequestId = 1,
                UserId = 4
            });

            modelBuilder.Entity<Offer>().HasData(new Offer
            {
                OfferId = 4,
                CreatedAt = DateTime.Now,
                OfferStatusId = 1,
                RequestId = 2,
                UserId = 4
            });

            modelBuilder.Entity<Rating>().HasData(new Rating
            {
                RatingId = 1,
                CreatedAt = DateTime.Now,
                Description = "Professionalism at the highest level!",
                RatingTypeId = 1,
                RequestId = 3,
                SupplierId = 4
            });
        }
    }
}
