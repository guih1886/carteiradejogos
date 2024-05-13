using System.Text;
using System.Text.Json;

namespace CarteiraDeJogosTest;

public class HttpClientBuilder
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string baseUrl = "http://localhost:5020";

    public async Task<HttpResponseMessage> CadastrarAsync<T>(string endPoint, T novoObjeto)
    {
        string json = JsonSerializer.Serialize(novoObjeto);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync(baseUrl + endPoint, httpContent);
        return response;
    }

    public async Task<HttpResponseMessage> BuscarAsync(string endPoint)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(baseUrl + endPoint);
        return response;
    }

    public async Task<HttpResponseMessage> DeletarAsync(string endPoint)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync(baseUrl + endPoint);
        return response;
    }

    public async Task<HttpResponseMessage> AlterarAsync<T>(string endPoint, T novoObjeto)
    {
        string json = JsonSerializer.Serialize(novoObjeto);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PutAsync(baseUrl + endPoint, httpContent);
        return response;
    }
}
