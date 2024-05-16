using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class Migrator
    {
        private AppDbContext _dbContext;

        public Migrator(AppDbContext appDbContext) => _dbContext = appDbContext;

        public void Migrate()
        {
            var pendingMigrations = _dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                _dbContext.Database.Migrate();
            }
        }
    }
}
