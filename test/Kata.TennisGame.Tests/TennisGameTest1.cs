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

            _player1.AddScore(1);

            Assert.Equal("Player1 advantage", _game.Result());
        }


        //[Fact]
        //public void ReturnPlayer2Advantage_WhenPlayerTwoScoreOneMore_GivenEachPlayerScoreThreePoints()
        //{
        //    for (var i = 0; i < 3; i++)
        //    {
        //        _game.AddScore(1, 1);
        //    }

        //    for (var i = 0; i < 3; i++)
        //    {
        //        _game.AddScore(1, 2);
        //    }

        //    _game.AddScore(1, 2);

        //    Assert.Equal("Player2 advantage", _game.Result());

        //}
    }

    public static class Mother
    {
        public static void AddSocres(int score, IPlayer player)
        {
            for (var i = 0; i < score; i++)
            {
                player.AddScore();
            }
        }
    }
}
