using Core.Entidad;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    public class CategoriaController : BaseApiController
    {
        private readonly IGenericRepository<Categoria> _CategoriaRepository;

        public CategoriaController(IGenericRepository<Categoria> CategoriaRepository)
        {
            _CategoriaRepository = CategoriaRepository;
        }
        //http://localhost:5000/api/Categoria
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetCategorias()
        {
            var Categorias = await _CategoriaRepository.GetAllAsync();
            return Ok(Categorias);
        }

        //http://localhost:5000/api/Categoria/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            return await _CategoriaRepository.GetByAsync(id);

        }
    }
}
