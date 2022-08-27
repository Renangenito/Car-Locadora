using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.ManutencaoVeiculo
{
    public class ManutencaoVeiculo : IManutencaoVeiculo
    {
        private readonly ControleCarLocadoraDBContext _entityContext;

        public ManutencaoVeiculo(ControleCarLocadoraDBContext entityContext)
        {
            _entityContext = entityContext;
        }



        public List<ManutencaoVeiculoModel> ListaManutencaoVeiculo()
        {
            return _entityContext.ManutencaoVeiculo.OrderBy(x => x.Id).ToList();
        }
        public ManutencaoVeiculoModel ObterUmaListaManutencaoVeiculo(int valor)
        {
            return _entityContext.ManutencaoVeiculo.Single(x => x.Id.Equals(valor));

        }
        public void AlterarListaManutencaoVeiculo(ManutencaoVeiculoModel manutencaoVeiculoModel)
        {
            _entityContext.ManutencaoVeiculo.Update(manutencaoVeiculoModel);
            _entityContext.SaveChanges();
        }
        public void IncluirListaManutencaoVeiculo(ManutencaoVeiculoModel manutencaoVeiculoModel)
        {
            _entityContext.ManutencaoVeiculo.Add(manutencaoVeiculoModel);
            _entityContext.SaveChanges();
        }

        public void ExcluirListaManutencaoVeiculo(int valor)
        {
            var id = _entityContext.ManutencaoVeiculo.Single(x => x.Id.Equals(valor));
            _entityContext.ManutencaoVeiculo.Remove(id);
            _entityContext.SaveChanges();
        }
    }
}
