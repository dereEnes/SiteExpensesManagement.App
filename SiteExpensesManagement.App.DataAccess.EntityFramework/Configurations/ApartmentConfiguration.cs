using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Configurations
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("Apartments", "dbo");
            builder.HasKey(x => x.Id);

            builder.HasOne<ApplicationUser>(a => a.User)
                .WithOne(au => au.Apartment)
                .HasForeignKey<Apartment>(a => a.UserId);

            builder.HasOne<RoomType>(a => a.RoomType)
                .WithMany(r => r.Apartments)
                .HasForeignKey(a => a.RoomTypeId);

            builder.Property(a => a.IsDeleted).HasDefaultValue(false);
        }
    }
}
