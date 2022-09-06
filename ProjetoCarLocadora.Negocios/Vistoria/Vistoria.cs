using Microsoft.EntityFrameworkCore;
using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.Vistoria
{
    public class Vistoria : IVistoria
    {
        private readonly ControleCarLocadoraDBContext _entityContext;

        public Vistoria(ControleCarLocadoraDBContext entityContext)
        {
            _entityContext = entityContext;
        }



        public async Task<List<VistoriaModel>> ListaVistorias()
        {
            return await _entityContext.Vistoria.OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<VistoriaModel> ObterUmaVistoria(int valor)
        {
            return await _entityContext.Vistoria.SingleAsync(x => x.Id.Equals(valor));

        }
        public async Task AlterarVistoria(VistoriaModel vistoriaModel)
        {
            _entityContext.Vistoria.Update(vistoriaModel);
            await _entityContext.SaveChangesAsync();
        }
        public async Task IncluirVistoria(VistoriaModel vistoriaModel)
        {
            _entityContext.Vistoria.Add(vistoriaModel);
            await _entityContext.SaveChangesAsync();
        }

     
    }
}
