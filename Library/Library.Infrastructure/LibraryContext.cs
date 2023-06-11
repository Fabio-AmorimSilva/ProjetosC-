using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure;

public class LibraryContext : DbContext
{
    public DbSet<Author> Authors {  get; set; }
    public DbSet<Book> Books {  get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<LibraryUnit> Libraries { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options): base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}
