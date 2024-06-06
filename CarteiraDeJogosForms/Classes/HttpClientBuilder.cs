using CarteiraDeJogosForms.Classes.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarteiraDeJogosForms.Classes
{
    public class HttpClientBuilder : IHttpClient
    {
        private HttpClient _httpClient;
        private string urlBase;
        private string jwt;

        public HttpClientBuilder(string urlBase, string jwt)
        {
            _httpClient = new HttpClient();
            this.urlBase = urlBase;
            this.jwt = jwt;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.jwt);
        }

        public async Task<HttpResponseMessage> GetRequisition(string endPoint)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync(urlBase + endPoint);
            return resposta;
        }
        public async Task<HttpResponseMessage> PostRequisition(string endPoint, object body)
        {
            StringContent content = GerarStringContent(body);
            HttpResponseMessage resposta = await _httpClient.PostAsync(urlBase + endPoint, content);
            return resposta;
        }
        public async Task<HttpResponseMessage> PutRequisition(string endPoint, object body)
        {
            StringContent content = GerarStringContent(body);
            HttpResponseMessage resposta = await _httpClient.PutAsync(urlBase + endPoint, content);
            return resposta;
        }
        public async Task<HttpResponseMessage> DeleteRequisition(string endPoint)
        {
            HttpResponseMessage resposta = await _httpClient.DeleteAsync(urlBase + endPoint);
            return resposta;
        }

        private StringContent GerarStringContent(object body)
        {
            string json = JsonConvert.SerializeObject(body);
            StringContent content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            return content;
        }
    }
}