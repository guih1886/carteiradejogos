using CarteiraDeJogos.Data;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Data.Repository;
using CarteiraDeJogos.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("CarteiraDeJogosTestConnection");

builder.Services.AddDbContext<JogosContext>(opts =>
    opts.UseSqlServer(connectionString, e => e.EnableRetryOnFailure()));

builder.Services.AddControllers();
builder.Services.AddScoped<IJogosRepository, JogosRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuarioRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "API Carteira de Jogos",
        Description = "O projeto carteira de jogos é uma API onde é possível cadastrar, alterar, deletar e adicionar os jogos aos favoritos.",
        Contact = new OpenApiContact() { Name = "LinkedIn", Url = new Uri("https://www.linkedin.com/in/guih1886/") },
    });
    opts.AddSecurityDefinition("1", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "Jwt",
        In = ParameterLocation.Header,
        Description = "Cabeçalho de autorização JWT está usando o esquema de Bearer, digite o jwt para fazer as requisições."
    });
    opts.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference()
            {
                Type = ReferenceType.SecurityScheme,
                Id = "1"
            }
        },
        Array.Empty<string>()
        }
    });
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
