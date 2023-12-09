using Domain.Users;
using Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public sealed class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfiguresUsersTable(builder);
    }

    private void ConfiguresUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                userId => userId.Value,
                value => new UserId(value));

        builder
            .Property(u => u.FirstName)
            .HasMaxLength(50);

        builder
            .Property(u => u.LastName)
            .HasMaxLength(50);

        builder
            .Property(u => u.Email)
            .HasMaxLength(150);

        builder.HasIndex(u => u.Email).IsUnique();

        builder
            .Property(u => u.Password);

    }
}
