using ProjetoCarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCarLocadora.Negocios.Cliente
{
    public interface ICliente
    {
        List<ClienteModel> ListaClientes();
        ClienteModel ObterUmCliente(string cpf);
        void IncluirCliente(ClienteModel clientesModel);
        void AlterarCliente(ClienteModel clientesModel);
        void ExcluirCliente(string cpf);

    }
}
