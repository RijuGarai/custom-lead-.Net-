using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repos
{
    public class FieldRepository : IFieldRepository
    {
        private readonly AppDbContext _context;

        public FieldRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Field?> GetByIdAsync(Guid id)
        {
            return await _context.Fields.FindAsync(id);
        }

        public async Task<IEnumerable<Field>> GetAllAsync()
        {
            return await _context.Fields.ToListAsync();
        }

        public async Task CreateAsync(Field field)
        {
            await _context.Fields.AddAsync(field);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Field field)
        {
            _context.Entry(field).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var field = await _context.Fields.FindAsync(id);
            if (field != null)
            {
                _context.Fields.Remove(field);
                await _context.SaveChangesAsync();
            }
        }
    }
}
