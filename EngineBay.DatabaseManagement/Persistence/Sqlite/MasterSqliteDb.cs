namespace EngineBay.DatabaseManagement
{
    using EngineBay.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class MasterSqliteDb : MasterDb
    {
        public MasterSqliteDb(DbContextOptions<ModuleWriteDbContext> options)
            : base(options)
        {
        }
    }
}