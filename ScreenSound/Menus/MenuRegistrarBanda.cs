using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegisterBand: Menu
{
    public override void Execute(Dictionary<string, Band> registeredBands)
    {
        base.Execute(registeredBands);

        Menu menu = new();
        menu.ShowOptionTitle("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string bandName = Console.ReadLine()!;
        Band band = new(bandName);
        registeredBands.Add(bandName, band);
        Console.WriteLine($"A banda {bandName} foi registrada com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}
