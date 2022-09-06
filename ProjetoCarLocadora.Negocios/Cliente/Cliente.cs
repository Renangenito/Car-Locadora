using ProjetoCarLocadora.Negocios.Cliente;
using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCarLocadora.Negocios.Cliente
{
    public class Cliente : ICliente
    {

      

        private readonly ControleCarLocadoraDBContext _entityContext;
        public Cliente(ControleCarLocadoraDBContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task AlterarCliente(ClienteModel clientesModel)
        {
            _entityContext.Clientes.Update(clientesModel);
            await _entityContext.SaveChangesAsync();
        }

        public async Task IncluirCliente(ClienteModel clientesModel)
        {
            _entityContext.Clientes.Add(clientesModel);
            await _entityContext.SaveChangesAsync();
        }  
        public async Task<List<ClienteModel>> ListaClientes()
        {
           return await _entityContext.Clientes.OrderBy(nome => nome.Nome).ToListAsync();
        }

        public async Task<ClienteModel> ObterUmCliente(string cpf)
        {
            return await _entityContext.Clientes.SingleAsync(x => x.Cpf.Equals(cpf));
        }

        public async Task ExcluirCliente(string cpf)
        {
            var cpfCliente = _entityContext.Clientes.Single(x => x.Cpf.Equals(cpf));
            _entityContext.Clientes.Remove(cpfCliente);
            await _entityContext.SaveChangesAsync();
        }
    }
}
