using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Web.Requests
{
    public record ArtistaRequestEdit(int Id, string nome, string bio, string? fotoPerfil = null) : ArtistaRequest(nome, bio, fotoPerfil);
}
