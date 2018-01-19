using System.Collections.Generic;
using System.Linq;

namespace Kata.TennisGame.Tests
{
    public class Player : IPlayer
    {
        private int _scores;

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public List<string> Scores()
        {
            var result = new List<string>();

            var cuurentScore = 1;

            for (var currentScore = 0; currentScore < _scores; cuurentScore++)
            {
                switch (cuurentScore)
                {
                    case 0:
                        result.Add("love");
                        break;
                    case 1:
                        result.Append("fifteen");
                        break;
                    case 2:
                        result.Append("thirty");
                        break;
                    case 3:
                        result.Append("forty");
                        break;
                }
            }

            return result;
        }

        public void AddScore(int newScore = 1)
        {
            _scores += newScore;
        }

    }
}