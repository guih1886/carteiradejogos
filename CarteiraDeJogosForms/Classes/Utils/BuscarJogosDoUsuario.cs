using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogosForms.Classes.Interfaces;
using Newtonsoft.Json;

namespace CarteiraDeJogosForms.Classes.Utils;

public static class BuscarJogosDoUsuario
{
    public static async Task<List<ReadJogosDto>> ConverterListaDeJogos(string endPoint, IHttpClient httpClient)
    {
        HttpResponseMessage jogosResponse = await httpClient.GetRequisition(endPoint);
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(await jogosResponse.Content.ReadAsStringAsync())!;
        List<ReadJogosDto> novaLista = new List<ReadJogosDto>();
        foreach (int item in lista)
        {
            ReadJogosDto? jogo = await BuscarJogo(item, httpClient);
            if (jogo != null) novaLista.Add(jogo);
        }
        novaLista.OrderBy(j => j.Id);
        return novaLista;
    }

    public static async Task<ReadJogosDto?> BuscarJogo(int id, IHttpClient httpClient)
    {
        HttpResponseMessage resposta = await httpClient.GetRequisition($"/Jogos/{id}");
        if (resposta.IsSuccessStatusCode)
        {
            ReadJogosDto jogo = JsonConvert.DeserializeObject<ReadJogosDto>(await resposta.Content.ReadAsStringAsync())!;
            return jogo;
        }
        return null;
    }
}
