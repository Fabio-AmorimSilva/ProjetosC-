using Library.Core.Core;

namespace Library.Infrastructure.Base;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options): base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ }

    private void SetCreateInfo()
    {
        if (ChangeTracker.Entries().All(e => e.State != EntityState.Added)) 
            return;
        
        var createdEntities = ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.State == EntityState.Added);

        foreach (var entity in createdEntities)
            entity.Entity.CreatedAt = DateTime.Now;
    }

    private void SetUpdateInfo()
    {
        if (ChangeTracker.Entries().All(e => e.State != EntityState.Modified)) 
            return;
        
        var modifiedEntities = ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.State == EntityState.Modified);

        foreach (var entity in modifiedEntities)
            entity.Entity.UpdatedAt = DateTime.Now;
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        SetCreateInfo();
        SetUpdateInfo();
        return base.SaveChangesAsync(cancellationToken);
    }
}