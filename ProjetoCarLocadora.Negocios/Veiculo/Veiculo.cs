using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.Veiculo
{
    public class Veiculo : IVeiculo
    {
        private readonly ControleCarLocadoraDBContext _entityContext;

        public Veiculo(ControleCarLocadoraDBContext entityContext)
        {
            _entityContext = entityContext;
        }

        public void AlterarVeiculos(VeiculoModel veiculosModel)
        {
            _entityContext.Veiculos.Update(veiculosModel);
            _entityContext.SaveChanges();
        }

        public void IncluirVeiculos(VeiculoModel veiculosModel)
        {
            _entityContext.Veiculos.Add(veiculosModel);
            _entityContext.SaveChanges();
        }

        public VeiculoModel ObterUmVeiculo(string valor)
        {
            return _entityContext.Veiculos.Single(x => x.Placa.Equals(valor));
        }

        public List<VeiculoModel> ListaVeiculos()
        {
            return _entityContext.Veiculos.ToList();
        }
    }
}
