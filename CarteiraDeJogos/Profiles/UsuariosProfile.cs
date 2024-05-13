using AutoMapper;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;

namespace CarteiraDeJogos.Profiles;

public class UsuariosProfile : Profile
{
    public UsuariosProfile()
    {
        CreateMap<Usuario, ReadUsuariosDto>();
        CreateMap<Usuario, UpdateUsuariosDto>();
        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<UpdateUsuariosDto, Usuario>();
        CreateMap<UpdateUsuariosDto, ReadUsuariosDto>();
    }
}
