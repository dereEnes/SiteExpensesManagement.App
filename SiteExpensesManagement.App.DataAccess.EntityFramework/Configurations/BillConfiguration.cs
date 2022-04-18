﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteExpensesManagement.App.Domain.Entities;
using System;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills", "dbo");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);

            builder.HasOne<Apartment>(b => b.Apartment)
                .WithMany(a => a.Bills)
                .HasForeignKey(b => b.ApartmentId);

            
            builder.Property(b => b.IsPayed).HasDefaultValue(false);
            builder.Property(b => b.Price).HasColumnType("decimal(18,2)");
        }
    }
}
