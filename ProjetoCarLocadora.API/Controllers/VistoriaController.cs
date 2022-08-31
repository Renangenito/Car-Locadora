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

            return _vistoria.ListaVistorias();

        }


        [HttpGet("ObterDadosVistoria")]

        public VistoriaModel Get([FromQuery] int id)
        {

            return _vistoria.ObterUmaVistoria(id);
        }

        [HttpPost()]
        public void Post([FromBody] VistoriaModel vistoriaModel)
        {
            vistoriaModel.DataInclusao = DateTime.Now;
            vistoriaModel.DataAlteracao = null;
            _vistoria.IncluirVistoria(vistoriaModel);
        }


        [HttpPut()]
        public void Put([FromBody] VistoriaModel vistoriaModel)
        {
            vistoriaModel.DataAlteracao = DateTime.Now;
            _vistoria.AlterarVistoria(vistoriaModel);
        }
    }
}
