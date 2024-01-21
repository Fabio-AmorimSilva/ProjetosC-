namespace Library.Infrastructure;

public class LibraryContext : BaseContext
{
    public DbSet<Author> Authors {  get; set; }
    public DbSet<Book> Books {  get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<LibraryUnit> Libraries { get; set; }
    
    public LibraryContext(DbContextOptions<BaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}
