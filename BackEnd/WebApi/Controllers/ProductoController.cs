using AutoMapper;
using Core.Entidad;
using Core.Especificacion;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Error;

namespace WebApi.Controllers
{
    public class ProductoController : BaseApiController
    {
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }
        //http://localhost:5000/api/producto
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductoDto>>> GetProductos([FromQuery] ProductoSpecificationParams productoParams)
        {
            var spec = new ProductoWithCategoriaSpecification(productoParams);
            var productos = await _productoRepository.GetAlldWithSpec(spec);
            var specCount = new ProductoForCountingSpecification(productoParams);
            var totalProductos = await _productoRepository.CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalProductos) / productoParams.PageSize);
            var totalPages = Convert.ToInt32(rounded);
            var data = _mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos);
            var Paginaciones = new Pagination<ProductoDto>
            {
                Count = totalProductos,
                Data = data,
                PageCount = totalPages,
                PageIndex = productoParams.PageIndex,
                PageSize = productoParams.PageSize
            };
            return Ok(Paginaciones);
        }

        //http://localhost:5000/api/producto/2
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            var spec = new ProductoWithCategoriaSpecification(id);
            var producto = await _productoRepository.GetByIdWithSpec(spec);

            if (producto == null)
            {
                return NotFound(new CodeErrorResponse(404, "El producto no existe"));
            }
            return _mapper.Map<Producto, ProductoDto>(producto);

        }

        //http://localhost:5000/api/producto/Categoria/2

        [HttpGet("Categoria/{categoriaid}")]
        public async Task<ActionResult<IReadOnlyList<ProductoDto>>> GetProductoByCategoria(int categoriaid)
        {
            var spec = new ProductoWithCategoriaSpecification(categoriaid,true);
            var productos = await _productoRepository.GetAlldWithSpec(spec);

            if (productos == null)
            {
                return NotFound(new CodeErrorResponse(404, "El producto no existe"));
            }
            return Ok(productos);

        }





    }
}
