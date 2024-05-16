using Domain;

namespace Persistance.Repos.Contracts
{
    public interface ITenantFieldRepository
    {
        Task<TenantField?> GetByIdAsync(Guid id);
        Task<IEnumerable<TenantField>> GetAllAsync();
        Task CreateAsync(TenantField tenantField);
        Task UpdateAsync(TenantField tenantField);
        Task DeleteAsync(Guid id);
    }
}
