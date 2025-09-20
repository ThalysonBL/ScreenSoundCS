namespace ScreenSound.Modelos;

internal class Music
{
    public Music(Band artist, string name)
    {
        Artist = artist;
        Name = name;
    }

    public string Name { get; }
    public Band Artist { get; }
    public int Duration { get; set; }
    public bool Available { get; set; }
    public string BriefDescription => $"A música {Name} pertence à banda {Artist}";

    public void ShowTechnicalSheet()
    {
        Console.WriteLine($"Nome: {Name}");
        Console.WriteLine($"Artista: {Artist.Name}");
        Console.WriteLine($"Duração: {Duration}");
        if (Available)
        {
            Console.WriteLine("Disponível no plano.");
        } else
        {
            Console.WriteLine("Adquira o plano Plus+");
        }
    }
}