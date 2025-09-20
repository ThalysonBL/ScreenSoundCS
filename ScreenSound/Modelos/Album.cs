using System.Linq;

namespace ScreenSound.Modelos;

internal class Album: IRateable
{
    private List<Music> musics = new List<Music>();
    private List<Rating> ratings = new();

    public Album(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public int TotalDuration => musics.Sum(a => a.Duration);
    public List<Music> Musics => musics;

    public double Average
    {
        get
        {
            if (ratings.Count == 0) return 0;
            return ratings.Average(a => a.Score);
        }
    }

    public void AddMusic(Music music)
    {
        musics.Add(music);
    }

    public void AddRating(Rating rating)
    {
        ratings.Add(rating);
    }

    public void ShowAlbumMusics()
    {
        Console.WriteLine($"Lista de músicas do álbum {Name}:\n");
        foreach (var music in musics)
        {
            Console.WriteLine($"Música: {music.Name}");
        }
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {TotalDuration}");
    }
}