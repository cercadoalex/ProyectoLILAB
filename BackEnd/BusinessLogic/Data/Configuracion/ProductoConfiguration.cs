using Core.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuracion
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Descripcion).HasMaxLength(1000);
            builder.Property(p => p.Precio);
            builder.HasOne(c => c.Categoria).WithMany().HasForeignKey(c => c.CategoriaId);



        }
    }
}
