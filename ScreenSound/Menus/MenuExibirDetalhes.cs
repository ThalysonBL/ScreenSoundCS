
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuShowDetails: Menu
{

    public override void Execute(Dictionary<string, Band> registeredBands)
    {
        base.Execute(registeredBands);
        ShowOptionTitle("Exibir detalhes da banda");
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
        string bandName = Console.ReadLine()!;
        if (registeredBands.ContainsKey(bandName))
        {
            Band band = registeredBands[bandName];

            Console.WriteLine($"\nA média da banda {bandName} é {band.Average}.");

            Console.WriteLine("\n Discografia:");
            foreach(Album album in band.Albums)
            {
                Console.WriteLine($"{album.Name} -> {album.Average}");
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

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
