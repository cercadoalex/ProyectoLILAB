using AutoMapper;
using Core.Entidad;

namespace WebApi.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember(p => p.CategoriaNombre, x => x.MapFrom(a => a.Categoria.Nombre)
               );
         
        }
    }
}
