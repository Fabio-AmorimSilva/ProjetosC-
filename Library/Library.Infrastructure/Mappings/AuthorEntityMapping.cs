namespace Library.Infrastructure.Mappings;

public class AuthorEntityMapping : BaseEntityMapping<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        base.Configure(builder);

        builder
            .Property(a => a.Name)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(a => a.Country)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(a => a.Birth)
            .IsRequired();

        builder
            .HasMany(a => a.Books)
            .WithOne(a => a.Author)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
