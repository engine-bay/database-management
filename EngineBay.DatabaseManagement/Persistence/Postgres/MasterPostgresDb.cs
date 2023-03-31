namespace EngineBay.DatabaseManagement
{
    using EngineBay.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class MasterPostgresDb : MasterDb
    {
        public MasterPostgresDb(DbContextOptions<ModuleWriteDbContext> options)
            : base(options)
        {
        }
    }
}