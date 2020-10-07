using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MoveMe.WebAPI.Database
{
    public partial class MoveMeContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "Germany" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "Spain" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, Name = "Italy" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 4, Name = "France" });

            modelBuilder.Entity<OfferStatus>().HasData(new OfferStatus { OfferStatusId = 1, Name = "Active" });
            modelBuilder.Entity<OfferStatus>().HasData(new OfferStatus { OfferStatusId = 2, Name = "Accepted" });
            modelBuilder.Entity<OfferStatus>().HasData(new OfferStatus { OfferStatusId = 3, Name = "Rejected" });

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
        }
    }
}
