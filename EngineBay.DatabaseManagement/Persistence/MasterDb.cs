namespace EngineBay.DatabaseManagement
{
    using EngineBay.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class MasterDb : ModuleWriteDbContext
    {
        public MasterDb(DbContextOptions<ModuleWriteDbContext> options)
            : base(options)
        {
        }

        protected virtual IReadOnlyCollection<IModuleDbContext> GetRegisteredDbContexts(IDbContextOptionsFactory dbContextOptionsFactory)
        {
            return new List<IModuleDbContext>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dbContextOptionsFactory = new DbContextOptionsFactory();
            var dbContexts = this.GetRegisteredDbContexts(dbContextOptionsFactory);

            foreach (var dbContext in dbContexts)
            {
                dbContext.MasterOnModelCreating(modelBuilder);
                dbContext.Dispose();
            }
        }
    }
}