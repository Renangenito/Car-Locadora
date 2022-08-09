using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.Categoria
{
    public class Categoria : ICategoria
    {

        #region Chamada Inteface

        private readonly ControleCarLocadoraDBContext _entityContext;

        public Categoria(ControleCarLocadoraDBContext entityContext)
        {
            _entityContext = entityContext;
        }
        #endregion


        public List<CategoriaModel> ListaCategorias()
        {
            return _entityContext.Categorias.OrderBy(x => x.Id).ToList();
        }
        public CategoriaModel ObterUmaCategoria(int valor)
        {
            return _entityContext.Categorias.Single(x => x.Id.Equals(valor));
            
        }
        public void AlterarCategoria(CategoriaModel categoriasModel)
        {
            _entityContext.Categorias.Update(categoriasModel);
            _entityContext.SaveChanges();
        }
        public void IncluirCategoria(CategoriaModel categoriasModel)
        {
            _entityContext.Categorias.Add(categoriasModel);
            _entityContext.SaveChanges();
        }

        public void ExcluirCategoria(int valor)
        {
            var id = _entityContext.Categorias.Single(x => x.Id.Equals(valor));
            _entityContext.Categorias.Remove(id);
            _entityContext.SaveChanges();
        }
    }
}
