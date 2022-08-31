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



        public List<VistoriaModel> ListaVistorias()
        {
            return _entityContext.Vistoria.OrderBy(x => x.Id).ToList();
        }
        public VistoriaModel ObterUmaVistoria(int valor)
        {
            return _entityContext.Vistoria.Single(x => x.Id.Equals(valor));

        }
        public void AlterarVistoria(VistoriaModel vistoriaModel)
        {
            _entityContext.Vistoria.Update(vistoriaModel);
            _entityContext.SaveChanges();
        }
        public void IncluirVistoria(VistoriaModel vistoriaModel)
        {
            _entityContext.Vistoria.Add(vistoriaModel);
            _entityContext.SaveChanges();
        }

     
    }
}
