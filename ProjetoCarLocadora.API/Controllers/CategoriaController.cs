using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Categoria;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        public readonly ICategoria _categoria;

        public CategoriaController(ICategoria categoria)
        {
            _categoria = categoria;
        }

        [HttpGet()]

        public async Task<List<CategoriaModel>> Get()
        {

            return _categoria.ListaCategorias();

        }


        [HttpGet("ObterDadosCategoria")]

        public CategoriaModel Get([FromQuery] int id)
        {

            return _categoria.ObterUmaCategoria(id);
        }

        [HttpPost()]
        public void Post([FromBody] CategoriaModel categoriaModel)
        {
            _categoria.IncluirCategoria(categoriaModel);
        }


        [HttpPut()]
        public void Put([FromBody] CategoriaModel categoriaModel)
        {
            _categoria.AlterarCategoria(categoriaModel);
        }

        [HttpDelete()]
        public void Delete([FromQuery] int id)
        {

            //Utilizando o Entity
            _categoria.ExcluirCategoria(id);
        }

    }
}
