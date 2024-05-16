using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.Repos.Contracts;

namespace Persistance.Repos.Concrete
{
    public class TenantFieldRepository : ITenantFieldRepository
    {
        private readonly AppDbContext _context;

        public TenantFieldRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TenantField?> GetByIdAsync(Guid id)
        {
            return await _context.TenantFields.FindAsync(id);
        }

        public async Task<IEnumerable<TenantField>> GetAllAsync()
        {
            return await _context.TenantFields.ToListAsync();
        }

        public async Task CreateAsync(TenantField tenantField)
        {
            _context.TenantFields.Add(tenantField);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TenantField tenantField)
        {
            _context.Entry(tenantField).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tenantField = await _context.TenantFields.FindAsync(id);
            if (tenantField != null)
            {
                _context.TenantFields.Remove(tenantField);
                await _context.SaveChangesAsync();
            }
        }
    }
}
