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
        Task<List<VeiculoModel>> ListaVeiculos();
        Task<VeiculoModel> ObterUmVeiculo(string valor);
        Task IncluirVeiculos(VeiculoModel veiculosModel);
        Task AlterarVeiculos(VeiculoModel veiculosModel);
    }
}
