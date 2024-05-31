using Microsoft.Extensions.Configuration;

namespace CarteiraDeJogosForms.Classes.Utils;

public static class InstanciaIConfiguration
{
    public static IConfiguration GetInstancia()
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        return builder.Build();
    }
}
