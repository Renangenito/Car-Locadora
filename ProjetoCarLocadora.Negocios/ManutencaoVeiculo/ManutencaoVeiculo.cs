using Microsoft.EntityFrameworkCore;
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



        public async Task<List<ManutencaoVeiculoModel>> ListaManutencaoVeiculo()
        {
            return await _entityContext.ManutencaoVeiculo.OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<ManutencaoVeiculoModel> ObterUmaListaManutencaoVeiculo(int valor)
        {
            return await _entityContext.ManutencaoVeiculo.SingleAsync(x => x.Id.Equals(valor));

        }
        public async Task AlterarListaManutencaoVeiculo(ManutencaoVeiculoModel manutencaoVeiculoModel)
        {
            _entityContext.ManutencaoVeiculo.Update(manutencaoVeiculoModel);
            await _entityContext.SaveChangesAsync();
        }
        public async Task IncluirListaManutencaoVeiculo(ManutencaoVeiculoModel manutencaoVeiculoModel)
        {
            _entityContext.ManutencaoVeiculo.Add(manutencaoVeiculoModel);
            _entityContext.SaveChangesAsync();
        }

        public async Task ExcluirListaManutencaoVeiculo(int valor)
        {
            var id = _entityContext.ManutencaoVeiculo.Single(x => x.Id.Equals(valor));
            _entityContext.ManutencaoVeiculo.Remove(id);
            await _entityContext.SaveChangesAsync();
        }
    }
}
