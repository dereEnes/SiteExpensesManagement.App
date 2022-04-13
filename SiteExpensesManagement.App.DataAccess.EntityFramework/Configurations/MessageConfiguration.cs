using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteExpensesManagement.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.hasRead).HasDefaultValue(false);

            builder.HasOne<ApplicationUser>(m => m.Sender)
                .WithMany(au => au.Messages)
                .HasForeignKey(m => m.SenderId);

            builder.Property(a => a.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(a => a.IsDeleted).HasDefaultValue(false);
        }
    }
}
