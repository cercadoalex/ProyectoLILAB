
using Core.Entidad;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class MarketDbContextData
    {
        public static async Task CargarDataAsync(MarketDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Categoria.Any())
                {
                    var categoriaData = File.ReadAllText("../BusinessLogic/CargaData/categoria.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriaData);
                    foreach (var categoria in categorias)
                    {
                        context.Categoria.Add(categoria);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Producto.Any())
                {
                    var ProductoData = File.ReadAllText("../BusinessLogic/CargaData/producto.json");
                    var productos = JsonSerializer.Deserialize<List<Producto>>(ProductoData);
                    foreach (var producto in productos)
                    {
                        context.Producto.Add(producto);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exp)
            {
                ILogger logger = loggerFactory.CreateLogger<MarketDbContextData>();
                logger.LogError(exp.Message);
            }
        }
    }
}
