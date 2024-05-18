using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Data.Repository;
using CarteiraDeJogos.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarteiraDeJogosTest;

public class UsuarioServiceProvider
{
    public T? AdicionarServico<T>()
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
        servico.AddTransient<IJogosDoUsuarioRepository, JogosDoUsuarioRepository>();
        servico.AddAutoMapper(typeof(UsuariosProfile).Assembly);
        var provedor = servico.BuildServiceProvider();
        var controler = provedor.GetService<T>();
        return controler;
    }
}
