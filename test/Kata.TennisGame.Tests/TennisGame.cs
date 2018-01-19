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
            var result = "";

            if (_player1.ContainsThirty()
                && _player2.ContainsThirty())
            {
                result += "advantage";

                if (_player1.ContainsForty())
                {
                    result = $"Player {_player1.Name} {result}";
                }
                else if (_player2.ContainsForty())
                {
                    result = $"Player {_player2.Name} {result}";
                }
            }

            return result;
        }
    }
}