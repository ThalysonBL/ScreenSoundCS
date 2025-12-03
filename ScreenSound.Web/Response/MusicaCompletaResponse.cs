using ScreenSound.Web.Response;

namespace ScreenSound.Web.Response
{
    public record MusicaCompletaResponse(
        int Id, 
        string Nome, 
        int? AnoLancamento, 
        int ArtistaId, 
        string NomeArtista,
        ICollection<GeneroResponse>? Generos);
}

