using System.Collections.Generic;

namespace Kata.TennisGame.Tests
{
    public interface IPlayer
    {
        string Name { get; }

        List<string> Scores();

        void AddScore(int newScore = 1);
    }
}