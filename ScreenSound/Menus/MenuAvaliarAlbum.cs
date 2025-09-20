using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRateAlbum: Menu
{
    public override void Execute(Dictionary<string, Band> registeredBands)
    {
        base.Execute(registeredBands);
        ShowOptionTitle("Avaliar Album");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string bandName = Console.ReadLine()!;
        if (registeredBands.ContainsKey(bandName))
        {
            Band band = registeredBands[bandName];

            Console.Write("Agora digite o titulo do album: ");
            string albumTitle = Console.ReadLine()!;

            if (band.Albums.Any(a => a.Name.Equals(albumTitle)))
            {
                Album album = band.Albums.First(a => a.Name.Equals(albumTitle));
                Console.Write($"Qual a nota que o álbum {albumTitle} merece: ");
                Rating rating = Rating.Parse(Console.ReadLine()!);
                album.AddRating(rating);
                Console.WriteLine($"\nA nota {rating.Score} foi registrada com sucesso para o álbum {albumTitle} da banda {bandName}");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"\nO álbum {albumTitle} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else
        {
            Console.WriteLine($"\nA banda {bandName} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
