﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Cliente;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            return _cliente.ListaClientes();

        }


        [HttpGet("ObterDadosCliente")]

        public ClienteModel Get([FromQuery] string cpf)
        {

            return _cliente.ObterUmCliente(cpf);
        }

        [HttpPost()]
        public async Task Post([FromBody] ClienteModel clienteModel)
        {
            clienteModel.DataInclusao = DateTime.Now;
            clienteModel.DataAlteracao = null;
            _cliente.IncluirCliente(clienteModel);
        }


        [HttpPut()]
        public void Put([FromBody] ClienteModel clienteModel)
        {
            clienteModel.DataAlteracao = DateTime.Now;
            _cliente.AlterarCliente(clienteModel);
        }



    }
}
