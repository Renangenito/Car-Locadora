using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.Usuario
{
    public class Usuario : IUsuario
    {
        private readonly ControleCarLocadoraDBContext _entityContext;

        public Usuario(ControleCarLocadoraDBContext entityContext)
        {
            _entityContext = entityContext;
        }

        public void AlterarUsuario(UsuarioModel usuariosModel)
        {
            _entityContext.Usuarios.Update(usuariosModel);
            _entityContext.SaveChanges();
        }

        public void IncluirUsuario(UsuarioModel usuariosModel)
        {
            _entityContext.Usuarios.Add(usuariosModel);
            _entityContext.SaveChanges();
        }

        public UsuarioModel ObterUmUsuario(string cpf)
        {
            return _entityContext.Usuarios.Single(x => x.Cpf.Equals(cpf));
        }

        public List<UsuarioModel> ListaUsuarios()
        {
            return _entityContext.Usuarios.ToList();
        }

    }
}
