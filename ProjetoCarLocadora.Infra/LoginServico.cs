using ProjetoCarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Infra
{
    public class LoginServico
    {
        public async Task<LoginRespostaModel> Login(LoginRequisicaoModel loginRequisicaoModel)
        {
            LoginRespostaModel loginRespostaModel = new LoginRespostaModel();
            loginRespostaModel.Autenticado = false;
            loginRespostaModel.Usuario = loginRequisicaoModel.Usuario;
            loginRespostaModel.Token = "";
            loginRespostaModel.DataExpiracao = null;


            if (loginRequisicaoModel.Usuario == "UsuarioCarLocadora" && loginRequisicaoModel.Senha == "SenhaCarLocadora")
            {
                loginRespostaModel = new GeradorToken().GerarToken(loginRespostaModel);
            }
            return loginRespostaModel;
        }
    }
}
