using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Data.Repository;
using CarteiraDeJogos.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarteiraDeJogosTest.Services;

public class UsuarioServiceProvider
{
    public UsuarioController AdicionarServico()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("CarteiraDeJogosTestConnection");

        var servico = new ServiceCollection();
        servico.AddDbContext<JogosContext>(opts =>
            opts.UseSqlServer(connectionString, e => e.EnableRetryOnFailure()));

        servico.AddTransient<IUsuariosRepository, UsuarioRepository>();
        servico.AddTransient<UsuarioController>();
        servico.AddTransient<IJogosRepository, JogosRepository>();
        servico.AddAutoMapper(typeof(UsuariosProfile).Assembly);
        var provedor = servico.BuildServiceProvider();
        var controler = provedor.GetService<UsuarioController>();
        return controler;
    }
}
