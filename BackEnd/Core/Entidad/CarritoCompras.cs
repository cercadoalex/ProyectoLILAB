using Core.Entidads;
using System.Collections.Generic;

namespace Core.Entidad
{
    public class CarritoCompras
    {
        public CarritoCompras()
        {

        }
        public CarritoCompras(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<CarritoItem> Items { get; set; } = new List<CarritoItem>();
    }
}
