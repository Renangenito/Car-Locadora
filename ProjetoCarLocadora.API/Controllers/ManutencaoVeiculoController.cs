using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.ManutencaoVeiculo;

namespace ProjetoCarLocadora.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ManutencaoVeiculoController : Controller
    {
        public readonly IManutencaoVeiculo _manutencaoVeiculo;

        public ManutencaoVeiculoController(IManutencaoVeiculo manutencaoVeiculo)
        {
            _manutencaoVeiculo = manutencaoVeiculo;
        }

        [HttpGet("ObterTodasManutencoesVeiculos")]

        public async Task<List<ManutencaoVeiculoModel>> Get()
        {

            return _manutencaoVeiculo.ListaManutencaoVeiculo();

        }


        [HttpGet("ObterDadosManutencaoVeiculo")]

        public ManutencaoVeiculoModel Get([FromQuery] int id)
        {

            return _manutencaoVeiculo.ObterUmaListaManutencaoVeiculo(id);
        }

        [HttpPost()]
        public void Post([FromBody] ManutencaoVeiculoModel manutencaoVeiculoModel)
        {
            manutencaoVeiculoModel.DataInclusao = DateTime.Now;
            manutencaoVeiculoModel.DataAlteracao = null;
            _manutencaoVeiculo.IncluirListaManutencaoVeiculo(manutencaoVeiculoModel);
        }


        [HttpPut()]
        public void Put([FromBody] ManutencaoVeiculoModel manutencaoVeiculoModel)
        {
            manutencaoVeiculoModel.DataAlteracao = DateTime.Now;
            _manutencaoVeiculo.AlterarListaManutencaoVeiculo(manutencaoVeiculoModel);
        }

        [HttpDelete()]
        public void Delete([FromQuery] int id)
        {

            //Utilizando o Entity
            _manutencaoVeiculo.ExcluirListaManutencaoVeiculo(id);
        }

    }
}
