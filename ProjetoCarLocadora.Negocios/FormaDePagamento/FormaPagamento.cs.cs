using Microsoft.EntityFrameworkCore;
using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Models.Models;


namespace ProjetoCarLocadora.Negocios.FormaDePagamento
{
    public class FormaPagamento : IFormaPagamento
    {
        private readonly ControleCarLocadoraDBContext _entityContext;

        public FormaPagamento(ControleCarLocadoraDBContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task AlterarFormaPagamento(FormaDePagamentoModel formasDePagamentosModel)
        {
            _entityContext.FormasDePagamento.Update(formasDePagamentosModel);
            await _entityContext.SaveChangesAsync();
        }

        public async Task IncluirFormaPagamento(FormaDePagamentoModel formasDePagamentosModel)
        {
            _entityContext.FormasDePagamento.Add(formasDePagamentosModel);
            await _entityContext.SaveChangesAsync();
        }

        public async Task<List<FormaDePagamentoModel>> ListaFormaPagamentos()
        {
            return await _entityContext.FormasDePagamento.ToListAsync();
        }

        public async Task<FormaDePagamentoModel> ObterFormaPagamento(int valor)
        {
            return await _entityContext.FormasDePagamento.SingleAsync(x => x.Id.Equals(valor));
        }
    }
}
