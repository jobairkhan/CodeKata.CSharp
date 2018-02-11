using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Kata.GreedGame
{
    public class GreedKataTest1
    {
        [Theory]
        [InlineData(000, 2, 3, 4, 6, 2)]
        [InlineData(050, 5, 3, 4, 6, 2)]
        [InlineData(100, 1, 3, 4, 6, 2)]
        public void RollRandomNumbers_ShouldReturn(int expectedScore, params int[] rollingNumbers)
        {
            var sut = new Greed();

            foreach (var t in rollingNumbers)
            {
                sut.Roll(t);
            }

            Assert.Equal(expectedScore, sut.Score());
        }

        [Theory]
        [InlineData(1000, 1, 1, 1, 2, 3)]
        [InlineData(200, 2, 2, 2, 3, 4)]
        [InlineData(300, 3, 3, 3, 4, 2)]
        [InlineData(400, 4, 4, 4, 3, 2)]
        [InlineData(600, 6, 6, 6, 3, 2)]
        public void RollSame3Numbers_ShouldReturn(int expectedScore, params int[] rollingNumbers)
        {
            var sut = new Greed();

            foreach (var t in rollingNumbers)
            {
                sut.Roll(t);
            }

            Assert.Equal(expectedScore, sut.Score());
        }

        [Theory]
        [InlineData(1050, 1, 1, 1, 5, 2)]
        [InlineData(1150, 1, 1, 1, 5, 1)]
        [InlineData(0, 2, 3,4,6,2)]
        [InlineData(350, 3,4,5,3,3)]
        [InlineData(250, 1, 5, 1, 2, 4)]
        [InlineData(600, 5, 5, 5, 5, 5)]
        public void RollNumbers_ShouldReturn(int expectedScore, params int[] rollingNumbers)
        {
            var sut = new Greed();

            foreach (var t in rollingNumbers)
            {
                sut.Roll(t);
            }

            Assert.Equal(expectedScore, sut.Score());
        }
    }

    public interface IGreedRules
    {
        int Execute();
    }

    public class GreedEqualRule : IGreedRules
    {
        private readonly int[] _dices;
        private readonly int _number;
        private readonly int _numberOfAppearance;
        private readonly int _scoreValue;

        public GreedEqualRule(
            int[] dices, 
            int number,
            int numberOfAppearance, 
            int scoreValue)
        {
            _dices = dices;
            _number = number;
            _numberOfAppearance = numberOfAppearance;
            _scoreValue = scoreValue;
        }

        public int Execute()
        {
            return
                _dices.Count(x => x == _number) == _numberOfAppearance 
                ? _scoreValue 
                : 0;
        }
    }

    public class GreedGreaterOeEqualRule : IGreedRules
    {
        private readonly int[] _dices;
        private readonly int _number;
        private readonly int _numberOfAppearance;
        private readonly int _scoreValue;

        public GreedGreaterOeEqualRule(
            int[] dices, 
            int number,
            int numberOfAppearance, 
            int scoreValue)
        {
            _dices = dices;
            _number = number;
            _numberOfAppearance = numberOfAppearance;
            _scoreValue = scoreValue;
        }

        public int Execute()
        {
            return
                _dices.Count(x => x == _number) >= _numberOfAppearance 
                ? _scoreValue 
                : 0;
        }
    }

    public class Greed
    {
        private readonly int[] _dices = new int[5];
        private int _currentIndex = 0;
        private readonly List<IGreedRules> _greedRules;

        public Greed()
        {
            _greedRules = new List<IGreedRules>
            {
                new GreedGreaterOeEqualRule(_dices, 1, 3, 1000),
                new GreedGreaterOeEqualRule(_dices, 2, 3, 200),
                new GreedGreaterOeEqualRule(_dices, 3, 3, 300),
                new GreedGreaterOeEqualRule(_dices, 4, 3, 400),
                new GreedGreaterOeEqualRule(_dices, 5, 3, 500),
                new GreedGreaterOeEqualRule(_dices, 6, 3, 600),
                new GreedEqualRule(_dices, 5, 5, 100),
                new GreedEqualRule(_dices, 5, 4, 50),
                new GreedEqualRule(_dices, 5, 2, 100),
                new GreedEqualRule(_dices, 5, 1, 50),
                new GreedEqualRule(_dices, 1, 5, 200),
                new GreedEqualRule(_dices, 1, 4, 100),
                new GreedEqualRule(_dices, 1, 2, 200),
                new GreedEqualRule(_dices, 1, 1, 100)
            };
        }

        public void Roll(int dice)
        {
            _dices[_currentIndex++] = dice;
        }

        public int Score()
        {
            var score = 0;
            foreach (var greedRule in _greedRules)
            {
                score += greedRule.Execute();
            }

            return score;
        }
    }
}
