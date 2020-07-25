using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MoveMe.WebAPI.Database
{
    public partial class MoveMeContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public MoveMeContext()
        {
        }

        public MoveMeContext(DbContextOptions<MoveMeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<RatingType> RatingType { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AdditionalAddress).HasMaxLength(70);

                entity.Property(e => e.City).HasMaxLength(70);

                entity.Property(e => e.Street).HasMaxLength(70);

                entity.Property(e => e.ZipCode).HasMaxLength(15);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Address__Country__267ABA7A");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(300);

                entity.HasOne(d => d.RatingType)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.RatingTypeId)
                    .HasConstraintName("FK__Rating__RatingTy__37A5467C");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__Rating__RequestI__36B12243");
            });

            modelBuilder.Entity<RatingType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.AdditionalInformation).HasMaxLength(300);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Request__ClientI__2F10007B");

                entity.HasOne(d => d.DeliveryAddressNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.DeliveryAddress)
                    .HasConstraintName("FK__Request__Deliver__300424B4");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Request__StatusI__30F848ED");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Company).HasMaxLength(70);

                entity.Property(e => e.FirstName).HasMaxLength(40);

                entity.Property(e => e.LastName).HasMaxLength(40);

                entity.Property(e => e.PhoneNumber).HasMaxLength(16);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__User__AddressId__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
