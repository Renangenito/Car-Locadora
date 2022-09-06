using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Categoria;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class CategoriaController : ControllerBase
    {

        public readonly ICategoria _categoria;

        public CategoriaController(ICategoria categoria)
        {
            _categoria = categoria;
        }

        [HttpGet("ObterTodasCategoria")]

        public async Task<List<CategoriaModel>> Get()
        {

            return await _categoria.ListaCategorias();

        }


        [HttpGet("ObterDadosCategoria")]

        public async Task<CategoriaModel> Get([FromQuery] int id)
        {

            return await _categoria.ObterUmaCategoria(id);
        }

        [HttpPost()]
        public async Task Post([FromBody] CategoriaModel categoriaModel)
        {
            categoriaModel.DataInclusao = DateTime.Now;
            categoriaModel.DataAlteracao = null;
            await _categoria.IncluirCategoria(categoriaModel);
        }


        [HttpPut()]
        public async Task Put([FromBody] CategoriaModel categoriaModel)
        {
            categoriaModel.DataAlteracao = DateTime.Now;
            await _categoria.AlterarCategoria(categoriaModel);
        }

        [HttpDelete()]
        public async Task Delete([FromQuery] int id)
        {

            //Utilizando o Entity
           await _categoria.ExcluirCategoria(id);
        }

    }
}
