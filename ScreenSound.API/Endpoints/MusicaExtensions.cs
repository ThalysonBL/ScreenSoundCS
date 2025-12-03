using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class MusicaExtensions
    {
        public static void AddEndpointMusicas(this WebApplication app)
        {


            #region Endpoint Músicas
            app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
            {
                return Results.Ok(dal.Listar());
            });

            app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
            {
                var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (musica is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(musica);

            });

            app.MapGet("/Musicas/id/{id}", ([FromServices] ScreenSoundContext context, int id) =>
            {
                var musica = context.Musicas
                    .Include(m => m.Artista)
                    .Include(m => m.Generos)
                    .AsNoTracking()
                    .FirstOrDefault(m => m.Id == id);
                    
                if (musica is null)
                {
                    return Results.NotFound();
                }

                var generosResponse = musica.Generos?.Select(g => new GeneroResponse(g.Id, g.Nome ?? "", g.Descricao ?? "")).ToList();
                var musicaCompleta = new
                {
                    Id = musica.Id,
                    Nome = musica.Nome,
                    AnoLancamento = musica.AnoLancamento,
                    ArtistaId = musica.Artista?.Id ?? 0,
                    NomeArtista = musica.Artista?.Nome ?? "",
                    Generos = generosResponse
                };

                return Results.Ok(musicaCompleta);
            });

            app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromServices] DAL<Genero> dalGenero, [FromServices] DAL<Artista> dalArtista, [FromBody] MusicaRequest musicaRequest) =>
            {
                var artista = dalArtista.RecuperarPor(a => a.Id == musicaRequest.ArtistaId);
                if (artista is null)
                {
                    return Results.BadRequest("Artista não encontrado.");
                }

                Musica musica = new(musicaRequest.nome)
                { 
                    Artista = artista,
                    AnoLancamento = musicaRequest.anoLancamento,
                    Generos = musicaRequest.Generos is not null ? GeneroRequestConverter(musicaRequest.Generos, dalGenero) : new List<Genero>(),
                };
                dal.Adicionar(musica);
                return Results.Ok();
            });

            app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) => {
                var musica = dal.RecuperarPor(a => a.Id == id);
                if (musica is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(musica);
                return Results.NoContent();

            });

            app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromServices] DAL<Genero> dalGenero, [FromServices] DAL<Artista> dalArtista, [FromBody] MusicaRequestEdit musicaRequestEdit) => {
                var musicaAAtualizar = dal.RecuperarPor(a => a.Id == musicaRequestEdit.Id);
                if (musicaAAtualizar is null)
                {
                    return Results.NotFound();
                }

                var artista = dalArtista.RecuperarPor(a => a.Id == musicaRequestEdit.ArtistaId);
                if (artista is null)
                {
                    return Results.BadRequest("Artista não encontrado.");
                }

                musicaAAtualizar.Nome = musicaRequestEdit.nome;
                musicaAAtualizar.AnoLancamento = musicaRequestEdit.anoLancamento;
                musicaAAtualizar.Artista = artista;
                musicaAAtualizar.Generos = musicaRequestEdit.Generos is not null ? GeneroRequestConverter(musicaRequestEdit.Generos, dalGenero) : new List<Genero>();

                dal.Atualizar(musicaAAtualizar);
                return Results.Ok();
            });

            app.MapGet("/Musicas/artista/{artistaId}", ([FromServices] ScreenSoundContext context, int artistaId) =>
            {
                var musicas = context.Musicas
                    .Include(m => m.Artista)
                    .AsNoTracking()
                    .Where(m => m.Artista != null && m.Artista.Id == artistaId)
                    .ToList();

                var musicasResponse = musicas.Select(m => new MusicaResponse(
                    m.Id,
                    m.Nome ?? "",
                    m.Artista?.Id ?? 0,
                    m.Artista?.Nome ?? ""
                )).ToList();

                return Results.Ok(musicasResponse);
            });

            app.MapGet("/Musicas/genero/{generoId}", ([FromServices] ScreenSoundContext context, int generoId) =>
            {
                var musicas = context.Musicas
                    .Include(m => m.Artista)
                    .Include(m => m.Generos)
                    .AsNoTracking()
                    .ToList()
                    .Where(m => m.Generos != null && m.Generos.Any(g => g.Id == generoId))
                    .ToList();

                var musicasResponse = musicas.Select(m => new MusicaResponse(
                    m.Id,
                    m.Nome ?? "",
                    m.Artista?.Id ?? 0,
                    m.Artista?.Nome ?? ""
                )).ToList();

                return Results.Ok(musicasResponse);
            });
            #endregion

        }

        private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos, DAL<Genero> dalGenero)
        {
            //return generos.Select(a => RequestToEntity(a)).ToList();
            var listaDeGeneros = new List<Genero>();
            foreach (var item in generos)
            {
                var entity = RequestToEntity(item);
                var genero = dalGenero.RecuperarPor(g => g.Nome.ToUpper().Equals(item.Nome.ToUpper()));

                if (genero is not null)
                {
                    listaDeGeneros.Add(genero);
                }
                else
                {
                    listaDeGeneros.Add(entity);
                }
            }
                return listaDeGeneros;
        }

        private static Genero RequestToEntity(GeneroRequest genero)
        {
            return new Genero(genero.Nome, genero.Descricao) { Nome = genero.Nome, Descricao = genero.Descricao };
        }
    }
}
