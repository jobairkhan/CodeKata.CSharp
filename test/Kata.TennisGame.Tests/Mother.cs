namespace Kata.TennisGame.Tests
{
    public static class Mother
    {
        public static void AddSocres(int score, IPlayer player)
        {
            for (var i = 0; i < score; i++)
            {
                player.AddScore();
            }
        }
    }
}