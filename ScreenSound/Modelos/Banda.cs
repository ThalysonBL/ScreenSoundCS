namespace ScreenSound.Modelos;
internal class Band: IRateable
{
    private List<Album> albums = new List<Album>();
    private List<Rating> ratings = new();

    public Band(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public double Average
    {
        get
        {
            if (ratings.Count == 0) return 0;
            else
            {
                return ratings.Average(a => a.Score);
            }
        }
    }
    public List<Album> Albums => albums;

    public void AddAlbum(Album album)
    {
        albums.Add(album);
    }

    public void AddRating(Rating rating)
    {
        ratings.Add(rating);
    }

    public void ShowDiscography()
    {
        Console.WriteLine($"Discografia da banda {Name}");
        foreach (Album album in albums)
        {
            Console.WriteLine($"Álbum: {album.Name} ({album.TotalDuration})");
        }
    }
}