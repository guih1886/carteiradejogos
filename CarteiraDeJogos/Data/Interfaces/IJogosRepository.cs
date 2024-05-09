using CarteiraDeJogos.Data.Dto.Jogos;

namespace CarteiraDeJogos.Data.Interfaces;

public interface IJogosRepository
{
    List<ReadJogosDto> ListarJogos();
    ReadJogosDto BuscarJogoPorId(int id);
    ReadJogosDto CadastrarJogo(CreateJogosDto jogo);
    ReadJogosDto AtualizarJogo(int id, UpdateJogosDto jogo);
    bool DeletarJogo(int id);
}
