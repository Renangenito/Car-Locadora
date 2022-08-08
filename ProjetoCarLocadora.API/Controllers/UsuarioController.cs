using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCarLocadora.Models.Models;
using ProjetoCarLocadora.Negocios.Usuario;

namespace ProjetoCarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            return _usuario.ListaUsuarios();

        }


        [HttpGet("ObterDadosUsuario")]

        public UsuarioModel Get([FromQuery] string cpf)
        {

            return _usuario.ObterUmUsuario(cpf);
        }

        [HttpPost()]
        public void Post([FromBody] UsuarioModel usuarioModel)
        {
            _usuario.IncluirUsuario(usuarioModel);
        }


        [HttpPut()]
        public void Put([FromBody] UsuarioModel usuarioModel)
        {
            _usuario.AlterarUsuario(usuarioModel);
        }
    }
}
