using ProjetoCarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.FormaDePagamento
{
    public interface IFormaPagamento
    {

        Task<List<FormaDePagamentoModel>> ListaFormaPagamentos();
        Task<FormaDePagamentoModel> ObterFormaPagamento(int valor);
        Task IncluirFormaPagamento(FormaDePagamentoModel formasDePagamentosModel);
        Task AlterarFormaPagamento(FormaDePagamentoModel formasDePagamentosModel);
    }
}
