using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services
{
    public class MusicaAPI
    {
        private readonly HttpClient _httpClient;

        public MusicaAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task AddMusicaAsync(MusicaRequest musica)
        {
            var response = await _httpClient.PostAsJsonAsync("musicas", musica);
            response.EnsureSuccessStatusCode();
        }

        public async Task<ICollection<MusicaResponse>?> GetMusicasAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
        }

        public async Task DeleteMusicaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"musicas/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<MusicaResponse?> GetMusicaPorNomeAsync(string nome)
        {
            return await _httpClient.GetFromJsonAsync<MusicaResponse>($"musicas/{nome}");
        }

        public async Task<MusicaCompletaResponse?> GetMusicaPorIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<MusicaCompletaResponse>($"musicas/id/{id}");
        }

        public async Task UpdateMusicaAsync(MusicaRequestEdit musica)
        {
            var response = await _httpClient.PutAsJsonAsync("musicas", musica);
            response.EnsureSuccessStatusCode();
        }

        public async Task<ICollection<MusicaResponse>?> GetMusicasPorArtistaAsync(int artistaId)
        {
            return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>($"musicas/artista/{artistaId}");
        }

        public async Task<ICollection<MusicaResponse>?> GetMusicasPorGeneroAsync(int generoId)
        {
            return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>($"musicas/genero/{generoId}");
        }
    }
}

