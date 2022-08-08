using ProjetoCarLocadora.Negocios.Cliente;
using ProjetoCarLocadora.Negocios.FormaDePagamento;
using ProjetoCarLocadora.Negocios.Usuario;
using ProjetoCarLocadora.Negocios.Veiculo;
using Microsoft.EntityFrameworkCore;
using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Negocios.Categoria;

namespace ProjetoCarLocadora.API.Extensoes
{
    public static class ServicoExtensoes
    {
        public static void ConfigurarServicos(this IServiceCollection services)
        {

            string connectionString = "Data source=localhost,1433;user id=sa;password=senha@1234xxxy;initial catalog=DBCarLocadora;";

            services.AddDbContext<ControleCarLocadoraDBContext>(item => item.UseSqlServer(connectionString));
            services.AddScoped<ICliente, Cliente>();
            services.AddScoped<ICategoria, Categoria>();
            services.AddScoped<IVeiculo, Veiculo>();
            services.AddScoped<IFormaPagamento, FormaPagamento>();
            services.AddScoped<IUsuario, Usuario>();
        }

    }
}
