using Microsoft.EntityFrameworkCore;
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

        public async Task AlterarUsuario(UsuarioModel usuariosModel)
        {
            _entityContext.Usuarios.Update(usuariosModel);
            await _entityContext.SaveChangesAsync();
        }

        public async Task IncluirUsuario(UsuarioModel usuariosModel)
        {
            _entityContext.Usuarios.Add(usuariosModel);
            await _entityContext.SaveChangesAsync();
        }

        public async Task<UsuarioModel> ObterUmUsuario(string cpf)
        {
            return await _entityContext.Usuarios.SingleAsync(x => x.Cpf.Equals(cpf));
        }

        public async Task<List<UsuarioModel>> ListaUsuarios()
        {
            return await _entityContext.Usuarios.ToListAsync();
        }

    }
}
