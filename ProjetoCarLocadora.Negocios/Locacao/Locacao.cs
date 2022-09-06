using Microsoft.EntityFrameworkCore;
using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.Locacao
{
    public class Locacao : ILocacao
    {
        private readonly ControleCarLocadoraDBContext _entityContext;

        public Locacao(ControleCarLocadoraDBContext entityContext)
        {
            _entityContext = entityContext;
        }



        public async Task<List<LocacaoModel>> ListaLocacoes()
        {
            return await _entityContext.Locacao.OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<LocacaoModel> ObterUmaLocacao(int valor)
        {
            return await _entityContext.Locacao.SingleAsync(x => x.Id.Equals(valor));

        }
        public async Task AlterarLocacao(LocacaoModel locacaoModel)
        {
            _entityContext.Locacao.Update(locacaoModel);
            await _entityContext.SaveChangesAsync();
        }
        public async Task IncluirLocacao(LocacaoModel locacaoModel)
        {
            _entityContext.Locacao.Add(locacaoModel);
            await _entityContext.SaveChangesAsync();
        }

    }
}
