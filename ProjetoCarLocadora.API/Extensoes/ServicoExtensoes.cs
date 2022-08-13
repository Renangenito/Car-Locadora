using ProjetoCarLocadora.Negocios.Cliente;
using ProjetoCarLocadora.Negocios.FormaDePagamento;
using ProjetoCarLocadora.Negocios.Usuario;
using ProjetoCarLocadora.Negocios.Veiculo;
using Microsoft.EntityFrameworkCore;
using ProjetoCarLocadora.Infra.Entity;
using ProjetoCarLocadora.Negocios.Categoria;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace ProjetoCarLocadora.API.Extensoes
{
    public static class ServicoExtensoes
    {

        public static void ConfigurarSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();

            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Autenticação JWT",
                Description = "Informe o token JWT Bearer **_somente_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };


            c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, Array.Empty<string>() }
                });
        });

        public static void ConfigurarJWT(this IServiceCollection services)
        {
            Environment.SetEnvironmentVariable("JWT_SECRETO", Convert.ToBase64String(new HMACSHA256().Key), EnvironmentVariableTarget.Process);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = "EmitenteDoJWT",
                        ValidAudience = "DestinatarioDoJWT",
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Convert.FromBase64String(Environment.GetEnvironmentVariable("JWT_SECRETO"))
                            )
                    };
                });
        }





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
