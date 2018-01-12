using System;
using Xunit;

namespace Kata.BowlingGame.Tests
{
    public class BowlingGameTest1
    {
        private readonly Game _game;

        public BowlingGameTest1()
        {
            _game = GetSut();
        }

        private void RollMany(int count, int pins)
        {
            for (int i = 0; i < count; i++)
            {
                _game.Roll(pins);
            }
        }

        private static Game GetSut()
        {
            return new Game();
        }

        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);

            Assert.Equal(0, _game.Score());
        }

        [Fact]
        public void TestAllOne()
        {
            RollMany(20, 1);

            Assert.Equal(20, _game.Score());
        }

        //[Fact]
        //public void TestOneSpare()
        //{
        //    _game.Roll(5);
        //    _game.Roll(5);
        //    _game.Roll(3);

        //    RollMany(17, 0);

        //    Assert.Equal(16, _game.Score());
        //}
    }

    public class Game
    {
        private int _score = 0;
        private int[] rolls = new int[21];
        private int _currentRoll = 0;


        public void Roll(int pins)
        {
            _score += pins;
            rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            return _score;
        }
    }
}
