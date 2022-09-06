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
        Task<List<ClienteModel>> ListaClientes();
        Task<ClienteModel> ObterUmCliente(string cpf);
        Task IncluirCliente(ClienteModel clientesModel);
        Task AlterarCliente(ClienteModel clientesModel);
        Task ExcluirCliente(string cpf);

    }
}
