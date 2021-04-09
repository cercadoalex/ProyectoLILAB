using Core.Entidad;

namespace Core.Especificacion
{
    public class ProductoWithCategoriaSpecification : BaseSpecification<Producto>
    {
        public ProductoWithCategoriaSpecification(ProductoSpecificationParams productoParams)
            : base(x =>
            (string.IsNullOrEmpty(productoParams.Search) || x.Nombre.Contains(productoParams.Search)) &&
            (!productoParams.Categoria.HasValue || x.CategoriaId == productoParams.Categoria))
        {
            AddInclude(p => p.Categoria);


            //ApplyPaging(0,5)
            ApplyPaging(productoParams.PageSize * (productoParams.PageIndex - 1), productoParams.PageSize);
            if (!string.IsNullOrEmpty(productoParams.Sort))
            {
                switch (productoParams.Sort)
                {
                    case "NombreAsc":
                        AddOrderBy(p => p.Nombre);
                        break;
                    case "NombreDesc":
                        AddOrderByDescending(p => p.Nombre);
                        break;
                    case "precioAsc":
                        AddOrderBy(p => p.Precio);
                        break;
                    case "precioDesc":
                        AddOrderByDescending(p => p.Precio);
                        break;
                    case "descripcionAsc":
                        AddOrderBy(p => p.Descripcion);
                        break;
                    case "descripcionDesc":
                        AddOrderByDescending(p => p.Descripcion);
                        break;
                    default:
                        AddOrderBy(p => p.Nombre);
                        break;
                }
            }
        }

        public ProductoWithCategoriaSpecification(int id) : base(x => x.ProductoId == id)
        {
            AddInclude(p => p.Categoria);
        }
        public ProductoWithCategoriaSpecification(int categoriaid,bool flag) : base(x => x.CategoriaId == categoriaid)
        {
           // AddInclude(p => p.Categoria);
        }
    }
}
