using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Cliente;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ClienteController : ControllerBase
    {
        public readonly ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;
        }

        [HttpGet("ObterTodosClientes")]

        public async Task<List<ClienteModel>> Get()
        {

            return await _cliente.ListaClientes();

        }


        [HttpGet("ObterDadosCliente")]

        public async Task<ClienteModel> Get([FromQuery] string cpf)
        {

            return await _cliente.ObterUmCliente(cpf);
        }

        [HttpPost()]
        public async Task Post([FromBody] ClienteModel clienteModel)
        {
            clienteModel.DataInclusao = DateTime.Now;
            clienteModel.DataAlteracao = null;
            await _cliente.IncluirCliente(clienteModel);
        }


        [HttpPut()]
        public async Task Put([FromBody] ClienteModel clienteModel)
        {
            clienteModel.DataAlteracao = DateTime.Now;
            await _cliente.AlterarCliente(clienteModel);
        }

        [HttpDelete()]
        public async Task Delete([FromQuery] string cpf)
        {

            //Utilizando o Entity
            await _cliente.ExcluirCliente(cpf);
        }

    }
}
