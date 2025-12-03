using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class ArtistasExtensions
    {
        public static void AddEndpointsArtistas(this WebApplication app)
        {
            #region Endpoint Artistas
            app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
            {
                var artistas = dal.Listar();
                var artistasResponse = artistas.Select(a => new ArtistaResponse(a.Id, a.Nome, a.Bio, a.FotoPerfil)).ToList();
                return Results.Ok(artistasResponse);
            });

            app.MapGet("/test", () => "API funcionando");

            app.MapGet("/Artistas/{nome}", ([FromServices] ScreenSoundContext context, string nome) =>
            {
                var artista = context.Artistas.AsNoTracking().FirstOrDefault(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (artista is null)
                {
                    return Results.NotFound();
                }
                var artistaResponse = new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
                return Results.Ok(artistaResponse);
            });

            app.MapPost("/Artistas", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
            {
                var nome = artistaRequest.nome.Trim();
                
                Artista artista = new(artistaRequest.nome, artistaRequest.bio);

                // Se houver foto, processa e salva
                if (!string.IsNullOrWhiteSpace(artistaRequest.fotoPerfil))
                {
                    var imagemArtista = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + nome.Replace(" ", "_") + ".jpeg";
                    var path = Path.Combine(env.ContentRootPath, "wwwroot", "fotosPerfil", imagemArtista);

                    // Garante que o diretório existe
                    var diretorio = Path.GetDirectoryName(path);
                    if (!string.IsNullOrEmpty(diretorio) && !Directory.Exists(diretorio))
                    {
                        Directory.CreateDirectory(diretorio);
                    }

                    artista.FotoPerfil = $"/fotosPerfil/{imagemArtista}";

                    using MemoryStream ms = new MemoryStream(Convert.FromBase64String(artistaRequest.fotoPerfil));
                    using FileStream fs = new FileStream(path, FileMode.Create);
                    await ms.CopyToAsync(fs);
                }
                // Se não houver foto, mantém o valor padrão do construtor

                dal.Adicionar(artista);
                return Results.Ok();
            });

            app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id) => {
                var artista = dal.RecuperarPor(a => a.Id == id);
                if (artista is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(artista);
                return Results.NoContent();

            });

            app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequestEdit) => {
                var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artistaRequestEdit.Id);
                if (artistaAAtualizar is null)
                {
                    return Results.NotFound();
                }
                artistaAAtualizar.Nome = artistaRequestEdit.nome;
                artistaAAtualizar.Bio = artistaRequestEdit.bio;

                dal.Atualizar(artistaAAtualizar);
                return Results.Ok();
            });
            #endregion

        }
    }
}
