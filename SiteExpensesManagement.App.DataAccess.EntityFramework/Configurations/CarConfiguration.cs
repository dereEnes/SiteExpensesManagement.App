using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteExpensesManagement.App.Domain.Entities;
using System;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(x => x.Id);

            builder.Property(c => c.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
            builder.Property(c => c.LicencePlate).HasMaxLength(20);

            builder.HasOne<ApplicationUser>(c => c.User)
                .WithMany(au => au.Cars)
                .HasForeignKey(c => c.UserId);

        }
    }
}
