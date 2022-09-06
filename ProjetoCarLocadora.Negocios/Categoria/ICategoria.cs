using ProjetoCarLocadora.Models.Models;

namespace ProjetoCarLocadora.Negocios.Categoria
{
    public interface ICategoria
    {


        Task<List<CategoriaModel>> ListaCategorias();
        Task<CategoriaModel> ObterUmaCategoria(int valor);
        Task AlterarCategoria(CategoriaModel categoriasModel);
        Task IncluirCategoria(CategoriaModel categoriasModel);
        Task ExcluirCategoria(int valor);
        

    }
}
