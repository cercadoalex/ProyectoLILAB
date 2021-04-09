using Core.Entidad;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ICarritoCompraRepository
    {
        Task<CarritoCompras> GetCarritoCompraAsync(string carritoId);
        Task<CarritoCompras> UpdateCarritoCompraAsync(CarritoCompras carritoCompra);
        Task<bool> DeleteCarritoCompraAsync(string carritoId);
    }
}
