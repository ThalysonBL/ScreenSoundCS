namespace ScreenSound.Modelos;

internal interface IRateable
{
    void AddRating(Rating rating);

    double Average { get; }
}
