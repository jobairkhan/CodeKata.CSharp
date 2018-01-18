using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Kata.TennisGame.Tests
{
    public class TennisGameTest1
    {
        private readonly TennisGame _game;

        public TennisGameTest1()
        {
            _game = new TennisGame();
        }

        [Fact]
        public void EmptyGameReturnsLove()
        {
            
            Assert.Equal("love", _game.Result());
        }

        [Theory]
        [InlineData(0, "love")]
        [InlineData(1, "fifteen")]
        [InlineData(2, "thirty")]
        [InlineData(3, "forty")]
        public void WhenSingleScoreAdded_ResultReturnsCorrectly(int score, string described)
        {
            _game.AddScore(score);

            Assert.Equal(described, _game.Result());
        }

        [Fact]
        public void Win_EachPlayerScoreThreePoints_WhenPlayerOneScore_ReturnsAdvantage()
        {
            for (int i = 0; i < 3; i++)
            {
                _game.AddScore(1, 1);
            }

            for (int i = 0; i < 3; i++)
            {
                _game.AddScore(1, 2);
            }

            _game.AddScore(1, 1);

            Assert.Equal("advantage", _game.Result());
        }
    }

    public class TennisGame
    {
        private readonly List<int> _scores = new List<int>();

        public void AddScore(int score,)
        {
            _scores.Add(score);
        }

        public string Result()
        {
            var cuurentScore = _scores.Sum();
            switch (cuurentScore)
            {
                case 1:
                    return "fifteen";
                case 2:
                    return "thirty";
                case 3:
                    return "forty";
            }

            return "love";
        }
    }
}
