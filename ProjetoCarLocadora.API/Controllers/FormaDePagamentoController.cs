using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.FormaDePagamento;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            return _formaPagamento.ListaFormaPagamentos();

        }


        [HttpGet("ObterDadosFormaPagamento")]

        public FormaDePagamentoModel Get([FromQuery] int id)
        {

            return _formaPagamento.ObterFormaPagamento(id);
        }

        [HttpPost()]
        public void Post([FromBody] FormaDePagamentoModel formaDePagamentoModel)
        {
            formaDePagamentoModel.DataInclusao = DateTime.Now;
            formaDePagamentoModel.DataAlteracao = null;
            _formaPagamento.IncluirFormaPagamento(formaDePagamentoModel);
        }


        [HttpPut()]
        public void Put([FromBody] FormaDePagamentoModel formaDePagamentoModel)
        {
            formaDePagamentoModel.DataAlteracao = DateTime.Now;
            _formaPagamento.AlterarFormaPagamento(formaDePagamentoModel);
        }
    }
}
