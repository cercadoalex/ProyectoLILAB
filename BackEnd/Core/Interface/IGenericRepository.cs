using Core.Especificacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAlldWithSpec(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
