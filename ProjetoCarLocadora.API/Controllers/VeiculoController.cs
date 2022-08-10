using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Veiculo;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            return _veiculo.ListaVeiculos();

        }


        [HttpGet("ObterDadosVeiculo")]

        public VeiculoModel Get([FromQuery] string placa)
        {

            return _veiculo.ObterUmVeiculo(placa);
        }

        [HttpPost()]
        public void Post([FromBody] VeiculoModel veiculoModel)
        {
             veiculoModel.DataInclusao = DateTime.Now;
             veiculoModel.DataAlteracao = null;
            _veiculo.IncluirVeiculos(veiculoModel);
        }


        [HttpPut()]
        public void Put([FromBody] VeiculoModel veiculoModel)
        {
             veiculoModel.DataAlteracao = DateTime.Now;
            _veiculo.AlterarVeiculos(veiculoModel);
        }
    }
}
