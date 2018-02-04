using Xunit;
using static Kata.TennisGame.Tests.Mother;

namespace Kata.TennisGame.Tests
{
    public class PlayerTest
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public PlayerTest()
        {
            _player1 = new Player("1");
            _player2 = new Player("2");
        }

        [Fact]
        public void EmptyGameReturnsLove()
        {
            Assert.Equal("love", _player1.Scores());
            Assert.Equal("love", _player2.Scores());
        }

        [Theory]
        [InlineData("1", 0, "love")]
        [InlineData("1", 1, "fifteen")]
        [InlineData("1", 2, "thirty")]
        [InlineData("1", 3, "forty")]
        [InlineData("2", 0, "love")]
        [InlineData("2", 1, "fifteen")]
        [InlineData("2", 2, "thirty")]
        [InlineData("2", 3, "forty")]
        public void WhenScoreAddedForPlayer1_ReturnAllScores(string playerNumber, int score, string expected)
        {
            var player = 
                _player1.Name == playerNumber 
                    ? _player1 
                    : _player2;

            AddSocres(score, player);
            
            Assert.Equal(expected, player.Scores());
        }
    }
}