using ProjetoCarLocadora.Negocios.Cliente;
using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Models.Models;

namespace ProjetoCarLocadora.Negocios.Cliente
{
    public class Cliente : ICliente
    {

      

        private readonly ControleCarLocadoraDBContext _entityContext;
        public Cliente(ControleCarLocadoraDBContext entityContext)
        {
            _entityContext = entityContext;
        }

        public void AlterarCliente(ClienteModel clientesModel)
        {
            _entityContext.Clientes.Update(clientesModel);
            _entityContext.SaveChanges();
        }

        public void IncluirCliente(ClienteModel clientesModel)
        {
            _entityContext.Clientes.Add(clientesModel);
            _entityContext.SaveChanges();
        }  
        public List<ClienteModel> ListaClientes()
        {
           return _entityContext.Clientes.OrderBy(nome => nome.Nome).ToList();
        }

        public ClienteModel ObterUmCliente(string cpf)
        {
            return _entityContext.Clientes.Single(x => x.Cpf.Equals(cpf));
        }

    }
}
