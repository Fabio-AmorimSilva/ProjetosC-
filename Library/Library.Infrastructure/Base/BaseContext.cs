namespace Library.Infrastructure.Base;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options): base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ }

    private void SetCreateInfo()
    {
        if (ChangeTracker.Entries().Any(e => e.State == EntityState.Added))
        {
            var createdEntities = ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added);

            foreach (var entity in createdEntities)
                entity.Entity.CreatedAt = DateTime.Now;
        }
    }

    private void SetUpdateInfo()
    {
        if (ChangeTracker.Entries().Any(e => e.State == EntityState.Modified))
        {
            var modifiedEntities = ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Modified);

            foreach (var entity in modifiedEntities)
                entity.Entity.UpdatedAt = DateTime.Now;
        }
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        SetCreateInfo();
        SetUpdateInfo();
        return base.SaveChangesAsync(cancellationToken);
    }
}