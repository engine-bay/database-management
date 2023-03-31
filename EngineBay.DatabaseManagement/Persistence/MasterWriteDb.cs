namespace EngineBay.DatabaseManagement
{
    using EngineBay.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class MasterWriteDb : MasterDb
    {
        public MasterWriteDb(DbContextOptions<ModuleWriteDbContext> options)
            : base(options)
        {
        }
    }
}