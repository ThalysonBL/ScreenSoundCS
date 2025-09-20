using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuExit: Menu
{
    public override void Execute(Dictionary<string, Band> registeredBands)
    {
        Console.WriteLine("Tchau tchau :)");
        return;
    }
}
