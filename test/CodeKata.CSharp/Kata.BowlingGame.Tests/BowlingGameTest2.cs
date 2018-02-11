using System;
using System.Linq;
using Xunit;

namespace Kata.BowlingGame.Tests
{
    public class BowlingGameTest2
    {
        private readonly BowlingGame1 _gameSut = new BowlingGame1();

        [Fact]
        public void TestGutterGame()
        {
            RollPin();

            Assert.Equal(0, _gameSut.Score());
        }

        [Theory]
        [InlineData(1, 20)]
        [InlineData(2, 40)]
        public void TestAll(int value, int score)
        {
            RollPin(20, value);

            Assert.Equal(score, _gameSut.Score());
        }

        [Fact]
        public void TestSpare()
        {
            RollSpare();
            _gameSut.Roll(3);

            RollPin(17);

            Assert.Equal(16, _gameSut.Score());
        }

        [Fact]
        public void TestSpare6thFrame()
        {
            RollPin(10);
            RollSpare();
            _gameSut.Roll(3);

            RollPin(4, 1);

            Assert.Equal(20, _gameSut.Score());
        }

        [Fact]
        public void TestStrike()
        {
            RollStrike();
            _gameSut.Roll(4);
            _gameSut.Roll(3);

            RollPin(17);

            Assert.Equal(17, _gameSut.Score());
        }

        private void RollStrike()
        {
            _gameSut.Roll(10);
        }

        private void RollSpare()
        {
            _gameSut.Roll(5);
            _gameSut.Roll(5);
        }

        private void RollPin(int balls = 20, int numberOfPin = 0)
        {
            for (var i = 0; i < balls; i++)
            {
                _gameSut.Roll(numberOfPin);
            }
        }
    }

    internal class BowlingGame1
    {
        readonly int[] _pins = new int[21];

        private int _currentRoll = 0;

        public int Score()
        {
            var score = 0;
            var frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + _pins[frameIndex + 1] + _pins[frameIndex + 2];
                    frameIndex += 3;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + _pins[frameIndex + 2];
                    frameIndex += 2;
                }
                else
                {
                    score += _pins[frameIndex++];
                    score += _pins[frameIndex++];
                }
            }
            return score;
        }

        public void Roll(int pin)
        {
            _pins[_currentRoll++] = pin;
        }

        private bool IsStrike(int frameIndex)
        {
            return _pins[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return _pins[frameIndex] + _pins[frameIndex + 1] == 10;
        }
    }
}
