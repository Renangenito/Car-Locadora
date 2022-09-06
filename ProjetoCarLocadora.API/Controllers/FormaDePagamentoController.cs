using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.FormaDePagamento;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class FormaDePagamentoController : ControllerBase
    {
        public readonly IFormaPagamento _formaPagamento;

        public FormaDePagamentoController(IFormaPagamento formaPagamento)
        {
            _formaPagamento = formaPagamento;
        }

        [HttpGet()]

        public async Task<List<FormaDePagamentoModel>> Get()
        {

            return await _formaPagamento.ListaFormaPagamentos();

        }


        [HttpGet("ObterDadosFormaPagamento")]

        public async Task<FormaDePagamentoModel> Get([FromQuery] int id)
        {

            return await _formaPagamento.ObterFormaPagamento(id);
        }

        [HttpPost()]
        public async Task Post([FromBody] FormaDePagamentoModel formaDePagamentoModel)
        {
            formaDePagamentoModel.DataInclusao = DateTime.Now;
            formaDePagamentoModel.DataAlteracao = null;
            await _formaPagamento.IncluirFormaPagamento(formaDePagamentoModel);
        }


        [HttpPut()]
        public async Task Put([FromBody] FormaDePagamentoModel formaDePagamentoModel)
        {
            formaDePagamentoModel.DataAlteracao = DateTime.Now;
            await _formaPagamento.AlterarFormaPagamento(formaDePagamentoModel);
        }
    }
}
