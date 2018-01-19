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
            Assert.Equal((string) "love", (string) JoinToTest(_player1));
        }

        [Theory]
        [InlineData("1", 0, "love")]
        [InlineData("1", 1, "love fifteen")]
        [InlineData("1", 2, "love fifteen thirty")]
        [InlineData("1", 3, "love fifteen thirty forty")]
        [InlineData("2", 0, "love")]
        [InlineData("2", 1, "love fifteen")]
        [InlineData("2", 2, "love fifteen thirty")]
        [InlineData("2", 3, "love fifteen thirty forty")]
        public void WhenScoreAddedForPlayer1_ReturnAllScores(string playerNumber, int score, string expected)
        {
            var player = 
                _player1.Name == playerNumber 
                    ? _player1 
                    : _player2;

            AddSocres(score, player);
            
            Assert.Equal(expected, JoinToTest(player));
        }
        
        private static string JoinToTest(IPlayer player)
        {
            return string.Join(" ", player.Scores());
        }
    }
}