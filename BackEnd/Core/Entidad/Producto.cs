namespace Core.Entidad
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
    }
}
