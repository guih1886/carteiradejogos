using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("CarteiraDeJogosConnection");

builder.Services.AddDbContext<JogosContext>(opts =>
    opts.UseSqlServer(connectionString, e => e.EnableRetryOnFailure()));

builder.Services.AddScoped<UsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<JogosRepository, JogosRepository>();
builder.Services.AddScoped<JogosDoUsuarioRepository, JogosDoUsuarioRepository>();

/*builder.Services.AddDbContext<JogosContext>(opts =>
    opts.UseSqlServer(connectionString, ServerVersion.AutoDetect(connectionString)));*/

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
