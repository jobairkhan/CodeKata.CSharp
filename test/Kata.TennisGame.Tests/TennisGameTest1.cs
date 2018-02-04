using System;
using System.Text;
using Xunit;

namespace Kata.TennisGame.Tests
{
    public class TennisGameTest1
    {

        private readonly TennisGame _game;
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public TennisGameTest1()
        {
            _player1 = new Player("1");
            _player2 = new Player("2");

            _game = new TennisGame(_player1, _player2);
        }

        [Fact]
        public void ReturnPlayer1Advantage_WhenPlayerOneScoreOneMore_GivenEachPlayerScoreThreePoints()
        {
            Mother.AddSocres(3, _player1);
            Mother.AddSocres(3, _player2);

            _player1.AddScore();

            Assert.Equal("Player 1 advantage", _game.Result());
        }


        [Fact]
        public void ReturnPlayer2Advantage_WhenPlayerTwoScoreOneMore_GivenEachPlayerScoreThreePoints()
        {

            Mother.AddSocres(3, _player1);
            Mother.AddSocres(3, _player2);

            _player2.AddScore();

            Assert.Equal("Player 2 advantage", _game.Result());
        }

        [Fact]
        public void ReturnDeuce_WhenBothPlayerScoresThree()
        {

            Mother.AddSocres(3, _player1);
            Mother.AddSocres(3, _player2);

            Assert.Equal("Deuce", _game.Result());
        }


        [Theory]
        [InlineData(0, "love-love")]
        [InlineData(1, "fifteen-love")]
        [InlineData(2, "thirty-love")]
        [InlineData(3, "forty-love")]
        [InlineData(4, "Player 1 winner")]
        public void ReturnCorrectResult_WhenOnlyPlayer1Scores_GivenPlayerTwoNil(int player1Score, string expectedResult)
        {
            Mother.AddSocres(player1Score, _player1);

            Assert.Equal(expectedResult, _game.Result());
        }

        [Theory]
        [InlineData(0, "love-love")]
        [InlineData(1, "love-fifteen")]
        [InlineData(2, "love-thirty")]
        [InlineData(3, "forty-love")]
        [InlineData(4, "Player 2 winner")]
        public void ReturnLoveFifteen_WhenOnlyPlayer2Scores_GivenPlayerOneNil(int player2Score, string expectedResult)
        {
            Mother.AddSocres(player2Score, _player2);

            Assert.Equal(expectedResult, _game.Result());
        }

        [Fact]
        public void ReturnPlayer1AsWinner_WhenPlayerScoresTwoMoreThanPlayer2()
        {
            Mother.AddSocres(4, _player1);
            Mother.AddSocres(2, _player2);

            Assert.Equal("Player 1 winner", _game.Result());
        }

    }
}
