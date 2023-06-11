﻿using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Mappings;

public class UserEntityMapping : BaseEntityMapping<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder
            .Property(u => u.Name)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(u => u.Email)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(u => u.Password)
            .HasMaxLength(256)
            .IsRequired();

        builder
            .Property(u => u.Role)
            .IsRequired();
    }
}