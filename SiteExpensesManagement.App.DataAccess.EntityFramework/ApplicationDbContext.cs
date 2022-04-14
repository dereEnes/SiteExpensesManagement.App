using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Configurations;
using SiteExpensesManagement.App.Domain.Entities;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        DbSet<Apartment> Apartments { get; set; }
        DbSet<Bill> Bills { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Dues> Dues { get; set; }
        DbSet<RoomType> RoomTypes { get; set; }
        DbSet<Message> Messages { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApartmentConfiguration());
            builder.ApplyConfiguration(new BillConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new DuesConfiguration());
            builder.ApplyConfiguration(new RoomTypeConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());

            builder.HasDefaultSchema("Identity");
            
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("Users");
                entity.Property<string>(x => x.FirstName).HasMaxLength(30);
                entity.Property<string>(x => x.LastName).HasMaxLength(30);
                entity.Property<string>(x => x.IdentityNumber).HasMaxLength(11);
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Roles");
                
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
