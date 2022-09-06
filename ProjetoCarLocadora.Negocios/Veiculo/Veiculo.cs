using Microsoft.EntityFrameworkCore;
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

        public async Task AlterarVeiculos(VeiculoModel veiculosModel)
        {
            _entityContext.Veiculos.Update(veiculosModel);
            await _entityContext.SaveChangesAsync();
        }

        public async Task IncluirVeiculos(VeiculoModel veiculosModel)
        {
            _entityContext.Veiculos.Add(veiculosModel);
            await _entityContext.SaveChangesAsync();
        }

        public async Task<VeiculoModel> ObterUmVeiculo(string valor)
        {
            return await _entityContext.Veiculos.SingleAsync(x => x.Placa.Equals(valor));
        }

        public async Task<List<VeiculoModel>> ListaVeiculos()
        {
            return await _entityContext.Veiculos.ToListAsync();
        }
    }
}
