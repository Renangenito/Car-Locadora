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
        List<LocacaoModel> ListaLocacoes();
        LocacaoModel ObterUmaLocacao(int valor);
        void AlterarLocacao(LocacaoModel locacaoModel);
        void IncluirLocacao(LocacaoModel locacaoModel);
    }
}
