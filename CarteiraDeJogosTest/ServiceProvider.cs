using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarteiraDeJogosTest;

public class ServiceProvider
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
        servico.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        var provedor = servico.BuildServiceProvider();
        var controler = provedor.GetService<T>();
        return controler;
    }
}
