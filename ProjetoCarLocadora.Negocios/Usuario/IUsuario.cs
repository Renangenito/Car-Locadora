using ProjetoCarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.Usuario
{
    public interface IUsuario
    {
        Task<List<UsuarioModel>> ListaUsuarios();
        Task<UsuarioModel> ObterUmUsuario(string cpf);
        Task IncluirUsuario(UsuarioModel usuariosModel);
        Task AlterarUsuario(UsuarioModel usuariosModel);
    }
}
