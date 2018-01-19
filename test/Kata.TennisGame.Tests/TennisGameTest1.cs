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
            Mother.AddSocres(2, _player1);
            Mother.AddSocres(2, _player2);

            _player1.AddScore();

            Assert.Equal("Player 1 advantage", _game.Result());
        }


        [Fact]
        public void ReturnPlayer2Advantage_WhenPlayerTwoScoreOneMore_GivenEachPlayerScoreThreePoints()
        {

            Mother.AddSocres(2, _player1);
            Mother.AddSocres(2, _player2);

            _player2.AddScore();

            Assert.Equal("Player 2 advantage", _game.Result());

        }
    }
}
