using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Usuario;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class UsuarioController : ControllerBase
    {

        public readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet()]

        public async Task<List<UsuarioModel>> Get()
        {

            return await _usuario.ListaUsuarios();

        }


        [HttpGet("ObterDadosUsuario")]

        public async Task<UsuarioModel> Get([FromQuery] string cpf)
        {

            return await _usuario.ObterUmUsuario(cpf);
        }

        [HttpPost()]
        public async Task Post([FromBody] UsuarioModel usuarioModel)
        {
             usuarioModel.DataInclusao = DateTime.Now;
             usuarioModel.DataAlteracao = null;
             await _usuario.IncluirUsuario(usuarioModel);
        }


        [HttpPut()]
        public async Task Put([FromBody] UsuarioModel usuarioModel)
        {
             usuarioModel.DataAlteracao = DateTime.Now;
             await _usuario.AlterarUsuario(usuarioModel);
        }
    }
}
