using Microsoft.EntityFrameworkCore;
using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Models.Models;


namespace ProjetoCarLocadora.Negocios.Categoria
{
    public class Categoria : ICategoria
    {


        private readonly ControleCarLocadoraDBContext _entityContext;

        public Categoria(ControleCarLocadoraDBContext entityContext)
        {
            _entityContext = entityContext;
        }
      


        public async Task<List<CategoriaModel>> ListaCategorias()
        {
            return await _entityContext.Categorias.OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<CategoriaModel> ObterUmaCategoria(int valor)
        {
            return await _entityContext.Categorias.SingleAsync(x => x.Id.Equals(valor));
            
        }
        public async Task AlterarCategoria(CategoriaModel categoriasModel)
        {
            _entityContext.Categorias.Update(categoriasModel);
            await _entityContext.SaveChangesAsync();
        }
        public async Task IncluirCategoria(CategoriaModel categoriasModel)
        {
            _entityContext.Categorias.AddAsync(categoriasModel);
            await _entityContext.SaveChangesAsync();
        }

        public async Task ExcluirCategoria(int valor)
        {
            var id = _entityContext.Categorias.Single(x => x.Id.Equals(valor));
            _entityContext.Categorias.Remove(id);
            _entityContext.SaveChanges();
        }
    }
}
