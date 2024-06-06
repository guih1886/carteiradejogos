using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogosForms.Classes.Interfaces;
using Newtonsoft.Json;

namespace CarteiraDeJogosForms.Classes.Utils;

public static class BuscarJogosDoUsuario
{
    public static async Task<List<ReadJogosDto>> BuscarTodosJogosDoUsuario(IHttpClient httpClient, int id)
    {
        HttpResponseMessage jogosResponse = await httpClient.GetRequisition($"/JogosDoUsuario/{id}/todosJogos");
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(await jogosResponse.Content.ReadAsStringAsync())!;
        List<ReadJogosDto> novaLista = new List<ReadJogosDto>();
        foreach (int item in lista)
        {
            HttpResponseMessage resposta = await httpClient.GetRequisition($"/Jogos/{item}");
            if (resposta.IsSuccessStatusCode)
            {
                ReadJogosDto jogo = JsonConvert.DeserializeObject<ReadJogosDto>(await resposta.Content.ReadAsStringAsync())!;
                novaLista.Add(jogo);
            }
        }
        return novaLista;
    }
}
