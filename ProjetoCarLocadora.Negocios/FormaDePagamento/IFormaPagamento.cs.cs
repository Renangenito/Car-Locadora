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

        List<FormaDePagamentoModel> ListaFormaPagamentos();
        FormaDePagamentoModel ObterFormaPagamento(int valor);
        void IncluirFormaPagamento(FormaDePagamentoModel formasDePagamentosModel);
        void AlterarFormaPagamento(FormaDePagamentoModel formasDePagamentosModel);
    }
}
