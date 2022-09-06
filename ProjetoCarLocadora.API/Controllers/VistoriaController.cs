using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Vistoria;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class VistoriaController : Controller
    {
        public readonly IVistoria _vistoria;

        public VistoriaController(IVistoria vistoria)
        {
            _vistoria = vistoria;
        }

        [HttpGet("ObterTodasVistorias")]

        public async Task<List<VistoriaModel>> Get()
        {

            return await _vistoria.ListaVistorias();

        }


        [HttpGet("ObterDadosVistoria")]

        public async Task<VistoriaModel> Get([FromQuery] int id)
        {

            return await _vistoria.ObterUmaVistoria(id);
        }

        [HttpPost()]
        public async Task Post([FromBody] VistoriaModel vistoriaModel)
        {
            vistoriaModel.DataInclusao = DateTime.Now;
            vistoriaModel.DataAlteracao = null;
            await _vistoria.IncluirVistoria(vistoriaModel);
        }


        [HttpPut()]
        public async Task Put([FromBody] VistoriaModel vistoriaModel)
        {
            vistoriaModel.DataAlteracao = DateTime.Now;
            await _vistoria.AlterarVistoria(vistoriaModel);
        }
    }
}
