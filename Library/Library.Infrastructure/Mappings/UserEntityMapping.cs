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
            .HasMaxLength(User.NameMaxLength)
            .IsRequired();

        builder
            .Property(u => u.Email)
            .HasMaxLength(User.EmailMaxLength)
            .IsRequired();

        builder
            .Property(u => u.Password)
            .HasMaxLength(User.PasswordMaxLength)
            .IsRequired();

        builder
            .Property(u => u.Role)
            .IsRequired();
    }
}
