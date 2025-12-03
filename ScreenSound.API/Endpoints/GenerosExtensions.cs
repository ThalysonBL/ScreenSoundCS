using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class GenerosExtensions
    {
        public static void AddEndpointsGeneros(this WebApplication app)
        {
            app.MapGet("/Generos", ([FromServices] DAL<Genero> dal) =>
            {
                return Results.Ok(dal.Listar());
            });

            app.MapGet("/Generos/{nome}", ([FromServices] DAL<Genero> dal, string nome) =>
            {
                var generos = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (generos is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(generos);
            });


            app.MapPost("/Generos", ([FromServices] DAL<Genero> dal, [FromBody] GeneroRequest generoRequest) =>
            {
                Genero genero = new(generoRequest.Nome, generoRequest.Descricao);
                dal.Adicionar(genero);
                return Results.Ok();
            });

            app.MapDelete("/Generos/{id}", ([FromServices] DAL<Genero> dal, int id) => {
                var genero = dal.RecuperarPor(a => a.Id == id);
                if (genero is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(genero);
                return Results.NoContent();

            });

            app.MapPut("/Generos", ([FromServices] DAL<Genero> dal, [FromBody] GeneroRequestEdit generoRequestEdit) =>
            {
                var generoAAtualizar = dal.RecuperarPor(a => a.Id == generoRequestEdit.Id);
                if (generoAAtualizar is null)
                {
                    return Results.NotFound();
                }
                generoAAtualizar.Nome = generoRequestEdit.Nome;

                dal.Atualizar(generoAAtualizar);
                return Results.Ok();
            });
        }
    }
}
