﻿using System.Data.Entity.ModelConfiguration;
using Domain.Users;

namespace DAL.EFConfiguration
{
    public class UserLoginMap : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginMap()
        {
            // Primary Key
            HasKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });

            // Properties
            Property(t => t.LoginProvider)
                .IsRequired()
                .HasMaxLength(128);

            Property(t => t.ProviderKey)
                .IsRequired()
                .HasMaxLength(128);

            Property(t => t.UserId)
                .IsRequired();
        }
    }
}