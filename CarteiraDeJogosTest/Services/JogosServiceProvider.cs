using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Data.Repository;
using CarteiraDeJogos.Profiles;
using CarteiraDeJogos.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarteiraDeJogosTest.Services;

public class JogosServiceProvider
{
    public JogosController AdicionarServico()
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
        servico.AddTransient<IJogosRepository, JogosRepository>();
        servico.AddTransient<JogosController>();
        servico.AddAutoMapper(typeof(JogosProfile).Assembly);

        var provedor = servico.BuildServiceProvider();
        var controler = provedor.GetService<JogosController>();
        return controler!;
    }
}
