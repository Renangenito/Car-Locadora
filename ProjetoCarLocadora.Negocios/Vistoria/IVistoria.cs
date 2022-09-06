using ProjetoCarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.Vistoria
{
    public interface IVistoria
    {
        Task<List<VistoriaModel>> ListaVistorias();
        Task<VistoriaModel> ObterUmaVistoria(int valor);
        Task AlterarVistoria(VistoriaModel vistoriaModel);
        Task IncluirVistoria(VistoriaModel vistoriaModel);
    }
}
