using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarteiraDeJogosForms.Classes
{
    public class HttpClientBuilder
    {
        private HttpClient _httpClient = new HttpClient();
        private string urlBase = "https://localhost:5020";

        public async Task<HttpResponseMessage> PostReq(string endPoint, object body)
        {
            string json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            HttpResponseMessage resposta = await _httpClient.PostAsync(urlBase + endPoint, content);
            return resposta;
        }
    }
}
