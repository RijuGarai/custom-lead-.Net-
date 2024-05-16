using Domain;

namespace Persistance.Repos
{
    public interface ITenantRepository
    {
        Task<Tenant?> GetByIdAsync(string id);
        Task<IEnumerable<Tenant>> GetAllAsync();
        Task CreateAsync(Tenant tenant);
        Task UpdateAsync(Tenant tenant);
        Task DeleteAsync(string id);
    }
}
