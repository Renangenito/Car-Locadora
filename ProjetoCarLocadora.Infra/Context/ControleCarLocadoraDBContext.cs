using Microsoft.EntityFrameworkCore;
using ProjetoCarLocadora.Models.Models;

namespace ProjetoCarLocadora.Infra.Entity
{
    public class ControleCarLocadoraDBContext : DbContext
    {

        public ControleCarLocadoraDBContext(DbContextOptions<ControleCarLocadoraDBContext> options) : base(options)
        {

        }

        public DbSet<CategoriaModel> Categorias { get; set; }

        public DbSet<ClienteModel> Clientes { get; set; }

        public DbSet<FormaDePagamentoModel> FormasDePagamento { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<VeiculoModel> Veiculos { get; set; }

    }
}
