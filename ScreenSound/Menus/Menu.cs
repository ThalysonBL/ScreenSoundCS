using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class Menu
{
    public void ShowOptionTitle(string title)
    {
        int letterCount = title.Length;
        string asterisks = string.Empty.PadLeft(letterCount, '*');
        Console.WriteLine(asterisks);
        Console.WriteLine(title);
        Console.WriteLine(asterisks + "\n");
    }

    public virtual void Execute(Dictionary<string, Band> registeredBands)
    {
        Console.Clear();

    }
}
