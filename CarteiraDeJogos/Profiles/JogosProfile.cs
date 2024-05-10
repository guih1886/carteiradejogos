using AutoMapper;
using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Models;
using Microsoft.OpenApi.Extensions;

namespace CarteiraDeJogos.Profiles;

public class JogosProfile : Profile
{
    public JogosProfile()
    {
        CreateMap<CreateJogosDto, Jogos>();
        CreateMap<UpdateJogosDto, Jogos>();
        CreateMap<UpdateJogosDto, ReadJogosDto>();
        CreateMap<Jogos, ReadJogosDto>();
        CreateMap<Jogos, UpdateJogosDto>();
    }
}
