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
        List<UsuarioModel> ListaUsuarios();
        UsuarioModel ObterUmUsuario(string cpf);
        void IncluirUsuario(UsuarioModel usuariosModel);
        void AlterarUsuario(UsuarioModel usuariosModel);
    }
}
