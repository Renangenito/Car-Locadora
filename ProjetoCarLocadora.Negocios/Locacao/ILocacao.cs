using ProjetoCarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.Locacao
{
    public interface ILocacao
    {
        Task<List<LocacaoModel>> ListaLocacoes();
        Task<LocacaoModel> ObterUmaLocacao(int valor);
        Task AlterarLocacao(LocacaoModel locacaoModel);
        Task IncluirLocacao(LocacaoModel locacaoModel);
    }
}
