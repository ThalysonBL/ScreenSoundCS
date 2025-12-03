namespace ScreenSound.Web.Requests
{
    public record MusicaRequestEdit(int Id, string nome, int ArtistaId, int anoLancamento, ICollection<GeneroRequest>? Generos = null): MusicaRequest(nome, ArtistaId, anoLancamento, Generos);
}
