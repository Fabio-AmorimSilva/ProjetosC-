namespace Library.Infrastructure.Mappings;

public class UserEntityMapping 
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users");

        builder
            .ConfigureEntityConventions();
        
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
