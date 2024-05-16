using CarteiraDeJogos.Data.Dto.Usuarios;

namespace CarteiraDeJogos.Data.Interfaces;

public interface ITokenService
{
    string GerarToken(LoginUsuarioDto usuario);
}