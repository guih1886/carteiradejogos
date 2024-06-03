using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Repository;
using CarteiraDeJogos.Models;

namespace CarteiraDeJogos.Data.Interfaces;

public interface IJogosRepository
{
    List<ReadJogosDto> ListarJogos();
    ReadJogosDto BuscarJogoPorId(int id);
    ReadJogosDto? CadastrarJogo(CreateJogosDto jogo);
    ReadJogosDto? AtualizarJogo(int id, UpdateJogosDto jogo);
    bool DeletarJogo(int id);
    ReadJogosDto AtivarJogo(int id, int idJogo);
    Jogos? BuscarJogo(int id);
    bool InativarJogo(int id, int idJogo);
}
