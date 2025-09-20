namespace ScreenSound.Modelos;

internal class Rating
{
    public Rating(int score)
    {
        if (score <= 0) score = 0;
        if (score >= 10) score = 10;
        Score = score;
    }
    public int Score { get; }

    public static Rating Parse(string text)
    {
        int score = int.Parse(text);
        return new Rating(score);
    }

    public int GetScore()
    {
        return Score;
    }
}
