using BusinessLogic.Data;
using Core.Entidad;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MarketDbContext _context;
        public ProductoRepository(MarketDbContext context)
        {
            _context = context;
        }
        public async Task<Producto> GetProductoByIdAsync(int productoid)
        {
            return await _context.Producto
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.ProductoId == productoid);
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await _context.Producto
                .Include(p => p.Categoria)
                .ToListAsync();
        }
    }
}
