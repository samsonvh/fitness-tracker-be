using FitnessTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Persistence.SqlServer.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");
            builder.HasKey(account => account.Id);
            builder.Property(account => account.Id).HasColumnName("account_id").IsRequired();

            builder.Property(account => account.Username).HasColumnName("username").IsRequired().HasMaxLength(50);
            builder.Property(account => account.Email).HasColumnName("email").IsRequired().HasMaxLength(100);
            builder.Property(account => account.PasswordHash).HasColumnName("password_hash").IsRequired().HasMaxLength(255);
            builder.Property(account => account.Role).HasColumnName("role").IsRequired();
            builder.Property(account => account.Status).HasColumnName("status").IsRequired();
            builder.Property(account => account.CreatedAt).HasColumnName("created_at").IsRequired();
        }
    }
}
