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
            var result = Winner();

            if (!string.IsNullOrWhiteSpace(result)) return result;

            if (BothScoresThirty())
            {
                if (EqualScore())
                {
                    result = "Deuce";
                }
            }
            else
            {
                result = $"{_player1.Scores()}-{_player2.Scores()}";
            }
            return result;
        }

        private bool BothScoresThirty()
        {
            return _player1.IsEqualOrMoreThanThirty() && _player2.IsEqualOrMoreThanThirty();
        }

        private string Winner()
        {
            if (_player1.TotalScore == 4)
            {
                return BuildWiningResultFor(_player1);
            }
            if (_player2.TotalScore == 4)
            {
                return BuildWiningResultFor(_player2);
            }
            return string.Empty;
        }

        private string BuildWiningResultFor(IPlayer player)
        {
            return $"Player {player.Name} {(BothScoresThirty() ? "advantage" : "winner")}";
        }

        private bool EqualScore()
        {
            return _player1.TotalScore == _player2.TotalScore;
        }
    }
}