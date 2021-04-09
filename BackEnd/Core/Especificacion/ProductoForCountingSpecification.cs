using Core.Entidad;

namespace Core.Especificacion
{
    public class ProductoForCountingSpecification : BaseSpecification<Producto>
    {
        public ProductoForCountingSpecification(ProductoSpecificationParams productoParams)
          : base(x =>
           (string.IsNullOrEmpty(productoParams.Search) || x.Nombre.Contains(productoParams.Search)) &&
          (!productoParams.Categoria.HasValue || x.CategoriaId == productoParams.Categoria))
        {
        }
    }
}
