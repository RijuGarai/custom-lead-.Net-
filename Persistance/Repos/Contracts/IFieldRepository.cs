using Domain;

namespace Persistance.Repos
{
    public interface IFieldRepository
    {
        Task<Field?> GetByIdAsync(Guid id);
        Task<IEnumerable<Field>> GetAllAsync();
        Task CreateAsync(Field field);
        Task UpdateAsync(Field field);
        Task DeleteAsync(Guid id);
    }
}
