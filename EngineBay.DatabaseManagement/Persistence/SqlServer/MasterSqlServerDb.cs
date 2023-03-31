namespace EngineBay.DatabaseManagement
{
    using EngineBay.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class MasterSqlServerDb : MasterDb
    {
        public MasterSqlServerDb(DbContextOptions<ModuleWriteDbContext> options)
            : base(options)
        {
        }
    }
}