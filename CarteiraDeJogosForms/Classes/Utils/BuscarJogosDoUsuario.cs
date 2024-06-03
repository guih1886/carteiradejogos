using CarteiraDeJogos.Data.Dto.Jogos;
using Newtonsoft.Json;

namespace CarteiraDeJogosForms.Classes.Utils;

public static class BuscarJogosDoUsuario
{
    public static async Task<List<ReadJogosDto>> BuscarTodosJogosDoUsuario(HttpClientBuilder httpClient, int id)
    {
        HttpResponseMessage jogosResponse = await httpClient.GetJogosDoUsuario(id);
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(await jogosResponse.Content.ReadAsStringAsync())!;
        List<ReadJogosDto> novaLista = new List<ReadJogosDto>();
        foreach (int item in lista)
        {
            HttpResponseMessage resposta = await httpClient.GetJogo(item);
            ReadJogosDto jogo = JsonConvert.DeserializeObject<ReadJogosDto>(await resposta.Content.ReadAsStringAsync())!;
            novaLista.Add(jogo);
        }
        return novaLista;
    }
}
