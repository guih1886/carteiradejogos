using Microsoft.Extensions.Configuration;

namespace CarteiraDeJogosForms.Classes
{
    public class HttpClientBuilder
    {
        private HttpClient _httpClient = new HttpClient();
        private string urlBase = "https://localhost:5020";

        public async Task<HttpResponseMessage> PostReq(string endPoint, HttpContent body)
        {
            HttpResponseMessage resposta = await _httpClient.PostAsync(urlBase + endPoint, body);
            return resposta;
        }
    }
}
