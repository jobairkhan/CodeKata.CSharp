namespace Kata.TennisGame.Tests
{
    public class TennisGame
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public TennisGame(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public string Result()
        {
            return "Player1 advantage";
        }
    }
}