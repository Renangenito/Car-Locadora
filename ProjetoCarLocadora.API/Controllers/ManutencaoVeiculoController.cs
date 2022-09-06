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

            return await _manutencaoVeiculo.ListaManutencaoVeiculo();

        }


        [HttpGet("ObterDadosManutencaoVeiculo")]

        public async Task<ManutencaoVeiculoModel> Get([FromQuery] int id)
        {

            return await _manutencaoVeiculo.ObterUmaListaManutencaoVeiculo(id);
        }

        [HttpPost()]
        public async Task Post([FromBody] ManutencaoVeiculoModel manutencaoVeiculoModel)
        {
            manutencaoVeiculoModel.DataInclusao = DateTime.Now;
            manutencaoVeiculoModel.DataAlteracao = null;
            await _manutencaoVeiculo.IncluirListaManutencaoVeiculo(manutencaoVeiculoModel);
        }


        [HttpPut()]
        public async Task Put([FromBody] ManutencaoVeiculoModel manutencaoVeiculoModel)
        {
            manutencaoVeiculoModel.DataAlteracao = DateTime.Now;
            await _manutencaoVeiculo.AlterarListaManutencaoVeiculo(manutencaoVeiculoModel);
        }

        [HttpDelete()]
        public async Task Delete([FromQuery] int id)
        {

            //Utilizando o Entity
            await _manutencaoVeiculo.ExcluirListaManutencaoVeiculo(id);
        }

    }
}
