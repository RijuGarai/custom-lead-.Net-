using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repos
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AppDbContext _context;

        public TenantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tenant?> GetByIdAsync(string id)
        {
            return await _context.Tenants.FindAsync(id);
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            return await _context.Tenants.ToListAsync();
        }

        public async Task CreateAsync(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tenant tenant)
        {
            _context.Entry(tenant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant != null)
            {
                _context.Tenants.Remove(tenant);
                await _context.SaveChangesAsync();
            }
        }
    }
}
