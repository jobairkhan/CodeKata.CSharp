using System.Collections.Generic;

namespace Kata.TennisGame.Tests
{
    public interface IPlayer
    {
        string Name { get; }

        int TotalScore { get; }

        string Scores();

        void AddScore(int newScore = 1);

        bool IsEqualOrMoreThanThirty();
    }
}