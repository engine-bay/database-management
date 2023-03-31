namespace EngineBay.DatabaseManagement
{
    using EngineBay.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class MasterQueryDb : MasterDb
    {
        public MasterQueryDb(DbContextOptions<ModuleWriteDbContext> options)
            : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new InvalidOperationException($"Tried to save changes on a read only db context {nameof(MasterQueryDb)}");
        }
    }
}