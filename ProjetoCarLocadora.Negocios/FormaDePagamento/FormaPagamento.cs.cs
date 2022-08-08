using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.FormaDePagamento
{
    public class FormaPagamento : IFormaPagamento
    {
        private readonly ControleCarLocadoraDBContext _entityContext;

        public FormaPagamento(ControleCarLocadoraDBContext entityContext)
        {
            _entityContext = entityContext;
        }

        public void AlterarFormaPagamento(FormaDePagamentoModel formasDePagamentosModel)
        {
            _entityContext.FormasDePagamento.Update(formasDePagamentosModel);
            _entityContext.SaveChanges();
        }

        public void IncluirFormaPagamento(FormaDePagamentoModel formasDePagamentosModel)
        {
            _entityContext.FormasDePagamento.Add(formasDePagamentosModel);
            _entityContext.SaveChanges();
        }

        public List<FormaDePagamentoModel> ListaFormaPagamentos()
        {
            return _entityContext.FormasDePagamento.ToList();
        }

        public FormaDePagamentoModel ObterFormaPagamento(int valor)
        {
            return _entityContext.FormasDePagamento.Single(x => x.Id.Equals(valor));
        }
    }
}
