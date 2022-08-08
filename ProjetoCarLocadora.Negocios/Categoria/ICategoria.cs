

using ProjetoCarLocadora.Models.Models;

namespace ProjetoCarLocadora.Negocios.Categoria
{
    public interface ICategoria
    {


        List<CategoriaModel> ListaCategorias();
        CategoriaModel ObterUmaCategoria(int valor);
        void AlterarCategoria(CategoriaModel categoriasModel);
        void IncluirCategoria(CategoriaModel categoriasModel);
        void ExcluirCategoria(int valor);
        

    }
}
