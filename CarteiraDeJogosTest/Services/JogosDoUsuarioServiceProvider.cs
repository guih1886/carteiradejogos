using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Data.Repository;
using CarteiraDeJogos.Data;
using CarteiraDeJogos.Profiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CarteiraDeJogosTest.Services
{
    public class JogosDoUsuarioServiceProvider
    {
        public JogosDoUsuarioController AdicionarServico()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("CarteiraDeJogosTestConnection");

            var servico = new ServiceCollection();
            servico.AddSingleton<IConfiguration>(configuration);
            servico.AddDbContext<JogosContext>(opts =>
                opts.UseSqlServer(connectionString, e => e.EnableRetryOnFailure()));

            servico.AddTransient<IUsuariosRepository, UsuarioRepository>();
            servico.AddTransient<JogosDoUsuarioController>();
            servico.AddTransient<IJogosRepository, JogosRepository>();
            servico.AddAutoMapper(typeof(UsuariosProfile).Assembly);
            servico.AddAutoMapper(typeof(JogosProfile).Assembly);
            var provedor = servico.BuildServiceProvider();
            var controler = provedor.GetService<JogosDoUsuarioController>();
            return controler;
        }
    }
}