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
        List<VistoriaModel> ListaVistorias();
        VistoriaModel ObterUmaVistoria(int valor);
        void AlterarVistoria(VistoriaModel vistoriaModel);
        void IncluirVistoria(VistoriaModel vistoriaModel);
    }
}
