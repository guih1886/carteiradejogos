using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarteiraDeJogos.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUsuariosRepository _usuarioRepository;

    public TokenService(IUsuariosRepository usuarioRepository, IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
    }

    public string GerarToken(LoginUsuarioDto usuario)
    {
        Usuario? usuarioDB = _usuarioRepository.BuscarUsuarioEmail(usuario.Email);
        //Verifica o e-mail e senha que foi passado com o cadastrado no banco de dados.
        if (usuarioDB == null || usuario.Email != usuarioDB.Email || usuario.Senha != usuarioDB.Senha)
        {
            return "E-mail ou senha inválido.";
        }
        //Faz a configuração o jwt
        SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "Não foi possível localizar a chave JTW."));
        string issuer = _configuration["Jwt:Key"]!;
        string audience = _configuration["Jwt:Audience"]!;
        SigningCredentials credenciais = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        //Opções do token
        var tokenOptions = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new[]
            {
                new Claim(type: "id", usuarioDB.Id.ToString()),
                new Claim(type: "email", usuarioDB.Email),
            },
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credenciais
            );
        //Geração do token
        string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return token;
    }
}