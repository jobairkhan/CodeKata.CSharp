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

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            _game.Roll(3);

            RollMany(17, 0);

            Assert.Equal(16, _game.Score());
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }
    }
}
