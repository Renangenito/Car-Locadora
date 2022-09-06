using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Veiculo;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class VeiculoController : ControllerBase
    {

        public readonly IVeiculo _veiculo;

        public VeiculoController(IVeiculo veiculo)
        {
            _veiculo = veiculo;
        }

        [HttpGet()]

        public async Task<List<VeiculoModel>> Get()
        {

            return await _veiculo.ListaVeiculos();

        }


        [HttpGet("ObterDadosVeiculo")]

        public async Task<VeiculoModel> Get([FromQuery] string placa)
        {

            return await _veiculo.ObterUmVeiculo(placa);
        }

        [HttpPost()]
        public async Task Post([FromBody] VeiculoModel veiculoModel)
        {
             veiculoModel.DataInclusao = DateTime.Now;
             veiculoModel.DataAlteracao = null;
             await _veiculo.IncluirVeiculos(veiculoModel);
        }


        [HttpPut()]
        public async Task Put([FromBody] VeiculoModel veiculoModel)
        {
             veiculoModel.DataAlteracao = DateTime.Now;
              await _veiculo.AlterarVeiculos(veiculoModel);
        }
    }
}
