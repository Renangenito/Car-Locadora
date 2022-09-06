using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Locacao;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class LocacaoController : ControllerBase
    {

        public readonly ILocacao _locacao;

        public LocacaoController(ILocacao locacao)
        {
            _locacao = locacao;
        }

        [HttpGet("ObterTodasLocacoes")]

        public async Task<List<LocacaoModel>> Get()
        {

            return await _locacao.ListaLocacoes();

        }


        [HttpGet("ObterDadosLocacao")]

        public async Task<LocacaoModel> Get([FromQuery] int id)
        {

            return await _locacao.ObterUmaLocacao(id);
        }

        [HttpPost()]
        public async Task Post([FromBody] LocacaoModel locacaoModel)
        {
            locacaoModel.DataInclusao = DateTime.Now;
            locacaoModel.DataAlteracao = null;
            await _locacao.IncluirLocacao(locacaoModel);
        }


        [HttpPut()]
        public async Task Put([FromBody] LocacaoModel locacaoModel)
        {
            locacaoModel.DataAlteracao = DateTime.Now;
            await _locacao.AlterarLocacao(locacaoModel);
        }
    }
}
