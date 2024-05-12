namespace Library.Infrastructure.Base;

public class BaseContext(DbContextOptions<BaseContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ }
}