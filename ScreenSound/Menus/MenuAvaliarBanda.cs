using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRateBand : Menu
{
    public override void Execute(Dictionary<string, Band> registeredBands)
    {
        base.Execute(registeredBands);
        ShowOptionTitle("Avaliar banda");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string bandName = Console.ReadLine()!;
        if (registeredBands.ContainsKey(bandName))
        {
            Band band = registeredBands[bandName];
            Console.Write($"Qual a nota que a banda {bandName} merece: ");
            Rating rating = Rating.Parse(Console.ReadLine()!);
            band.AddRating(rating);
            Console.WriteLine($"\nA nota {rating.Score} foi registrada com sucesso para a banda {bandName}");
            Thread.Sleep(2000);
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
