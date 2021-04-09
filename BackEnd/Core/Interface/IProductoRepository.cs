using Core.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IProductoRepository
    {
        Task<Producto> GetProductoByIdAsync(int id);
        Task<IReadOnlyList<Producto>> GetProductosAsync();
    }
}
