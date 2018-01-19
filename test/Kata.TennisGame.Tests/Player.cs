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

            for (var currentScore = 0; currentScore <= _scores; currentScore++)
            {
                switch (currentScore)
                {
                    case 0:
                        result.Add("love");
                        break;
                    case 1:
                        result.Add("fifteen");
                        break;
                    case 2:
                        result.Add("thirty");
                        break;
                    case 3:
                        result.Add("forty");
                        break;
                }
            }

            return result;
        }

        public void AddScore(int newScore = 1)
        {
            _scores += newScore;
        }

        public bool ContainsThirty()
        {
            return
                Scores()
                    .Any(x => x.ToLower() == "thirty");
        }

        public bool ContainsForty()
        {
            return
                Scores()
                    .Any(x => x.ToLower() == "forty");
        }
    }
}