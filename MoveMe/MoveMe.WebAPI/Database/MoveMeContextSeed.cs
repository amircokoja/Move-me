using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<Address>().HasData(new Address{ AddressId = 1, CountryId = 1 });

            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 2, Name = "Client", NormalizedName = "CLIENT" });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 3, Name = "Supplier", NormalizedName = "SUPPLIER" });

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Active = true, AddressId = 1, FirstName = "Admin", LastName = "Admin", UserName = "admin@admin.com", NormalizedUserName = "admin@admin.com".ToUpper(),
            Email = "admin@admin.com", NormalizedEmail = "admin@admin.com".ToUpper(), EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "qweasd"), SecurityStamp = string.Empty });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { RoleId = 1, UserId = 1 });
        
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { NotificationTypeId = 1, Type = "New request" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { NotificationTypeId = 2, Type = "Offer accepted" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { NotificationTypeId = 3, Type = "Offer rejected" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { NotificationTypeId = 4, Type = "Offer finished" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { NotificationTypeId = 5, Type = "Feedback" });
        }
    }
}
