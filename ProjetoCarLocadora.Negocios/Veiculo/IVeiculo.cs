using ProjetoCarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.Veiculo
{
    public interface IVeiculo
    {
        List<VeiculoModel> ListaVeiculos();
        VeiculoModel ObterUmVeiculo(string valor);
        void IncluirVeiculos(VeiculoModel veiculosModel);
        void AlterarVeiculos(VeiculoModel veiculosModel);
    }
}
