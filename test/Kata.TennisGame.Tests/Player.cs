using System.Collections.Generic;
using System.Linq;

namespace Kata.TennisGame.Tests
{
    public class Player : IPlayer
    {
        private int _scored;

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public int TotalScore => _scored;

        public string Scores()
        {
            var result = "";

            switch (_scored)
            {
                case 0:
                    result = "love";
                    break;
                case 1:
                    result = "fifteen";
                    break;
                case 2:
                    result = "thirty";
                    break;
                case 3:
                    result = "forty";
                    break;
            }

            return result;
        }

        public void AddScore(int newScore = 1)
        {
            _scored += newScore;
        }

        public bool IsEqualOrMoreThanThirty()
        {
            return _scored >= 3;
        }
    }
}