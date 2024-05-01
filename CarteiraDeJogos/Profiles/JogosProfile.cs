using AutoMapper;
using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Models;

namespace CarteiraDeJogos.Profiles;

public class JogosProfile : Profile
{
    public JogosProfile()
    {
        CreateMap<CreateJogosDto, Jogos>();
        CreateMap<UpdateJogosDto, Jogos>();
        CreateMap<Jogos, ReadJogosDto>();
    }
}
