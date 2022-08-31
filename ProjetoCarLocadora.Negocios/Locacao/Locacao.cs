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



        public List<LocacaoModel> ListaLocacoes()
        {
            return _entityContext.Locacao.OrderBy(x => x.Id).ToList();
        }
        public LocacaoModel ObterUmaLocacao(int valor)
        {
            return _entityContext.Locacao.Single(x => x.Id.Equals(valor));

        }
        public void AlterarLocacao(LocacaoModel locacaoModel)
        {
            _entityContext.Locacao.Update(locacaoModel);
            _entityContext.SaveChanges();
        }
        public void IncluirLocacao(LocacaoModel locacaoModel)
        {
            _entityContext.Locacao.Add(locacaoModel);
            _entityContext.SaveChanges();
        }

    }
}
