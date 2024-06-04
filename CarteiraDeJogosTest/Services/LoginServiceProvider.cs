using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Data.Repository;
using CarteiraDeJogos.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarteiraDeJogosTest.Services;

public class LoginServiceProvider
{
    public LoginController AdicionarServico()
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
        servico.AddTransient<IUsuariosRepository, UsuarioRepository>();
        servico.AddTransient<ITokenService, TokenService>();
        servico.AddSingleton<IConfiguration>(configuration);
        servico.AddTransient<LoginController>();
        servico.AddAutoMapper(typeof(LoginController).Assembly);

        var provedor = servico.BuildServiceProvider();
        var controler = provedor.GetService<LoginController>();
        return controler!;
    }
}
