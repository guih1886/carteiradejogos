﻿using CarteiraDeJogos.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace CarteiraDeJogosForms.Classes
{
    public class HttpClientBuilder
    {
        private HttpClient _httpClient;
        private string urlBase;
        private string jwt;

        public HttpClientBuilder(string urlBase, string jwt)
        {
            _httpClient = new HttpClient();
            this.urlBase = urlBase;
            this.jwt = jwt;
        }

        public async Task<HttpResponseMessage> PostReq(string endPoint, object body)
        {
            string json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            HttpResponseMessage resposta = await _httpClient.PostAsync(urlBase + endPoint, content);
            return resposta;
        }
        public async Task<HttpResponseMessage> PutReq(string endPoint, object body)
        {
            string json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            HttpResponseMessage resposta = await _httpClient.PutAsync(urlBase + endPoint, content);
            return resposta;
        }
        public async Task<HttpResponseMessage> GetJogosDoUsuario(int usuarioId)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync(urlBase + $"/JogosDoUsuario/{usuarioId}/todosJogos");
            return resposta;
        }
        public async Task<HttpResponseMessage> GetJogosFavoritosDoUsuario(int usuarioId)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync(urlBase + $"/JogosDoUsuario/{usuarioId}/jogosfavoritos");
            return resposta;
        }
        public async Task<HttpResponseMessage> GetJogo(int id)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync(urlBase + $"/Jogos/{id}");
            return resposta;
        }
        public async Task<HttpResponseMessage> GetUsuario(int usuarioId)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync(urlBase + $"/Usuarios/{usuarioId}");
            return resposta;
        }

        public async Task<HttpResponseMessage> RemoverJogoFavorito(int usuarioId, int jogoId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            HttpResponseMessage resposta = await _httpClient.DeleteAsync(urlBase + $"/JogosDoUsuario/{usuarioId}/removerJogoFavorito/{jogoId}");
            return resposta;
        }

        public async Task<HttpResponseMessage> AdicionarJogoAoFavorito(int usuarioId, int jogoId)
        {
            string json = JsonConvert.SerializeObject("");
            var content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            HttpResponseMessage resposta = await _httpClient.PostAsync(urlBase + $"/JogosDoUsuario/{usuarioId}/adicionarJogoFavorito/{jogoId}", content);
            return resposta;
        }

        public async Task<HttpResponseMessage> DeletarJogo(int jogoId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            HttpResponseMessage resposta = await _httpClient.DeleteAsync(urlBase + $"/Jogos/{jogoId}");
            return resposta;
        }
    }
}
