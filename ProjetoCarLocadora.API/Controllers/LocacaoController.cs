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

            return _locacao.ListaLocacoes();

        }


        [HttpGet("ObterDadosLocacao")]

        public LocacaoModel Get([FromQuery] int id)
        {

            return _locacao.ObterUmaLocacao(id);
        }

        [HttpPost()]
        public void Post([FromBody] LocacaoModel locacaoModel)
        {
            locacaoModel.DataInclusao = DateTime.Now;
            locacaoModel.DataAlteracao = null;
            _locacao.IncluirLocacao(locacaoModel);
        }


        [HttpPut()]
        public void Put([FromBody] LocacaoModel locacaoModel)
        {
            locacaoModel.DataAlteracao = DateTime.Now;
            _locacao.AlterarLocacao(locacaoModel);
        }
    }
}
