using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuShowRegisteredBands: Menu
{
    public override void Execute(Dictionary<string, Band> registeredBands)
    {
        base.Execute(registeredBands);

        Menu menu = new();
        menu.ShowOptionTitle("Exibindo todas as bandas registradas na nossa aplicação");

        foreach (string band in registeredBands.Keys)
        {
            Console.WriteLine($"Banda: {band}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
