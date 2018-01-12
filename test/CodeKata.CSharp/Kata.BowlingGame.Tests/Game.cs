using System;

namespace Kata.BowlingGame.Tests
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int _currentRoll = 0;


        public void Roll(int pins)
        {
            rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            var score = 0;
            var frameIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (IsSpare(frameIndex))
                {
                    score += 10 + rolls[frameIndex + 2];
                }
                else
                {
                    score += rolls[frameIndex] + rolls[frameIndex + 1];
                }

                frameIndex += 2;
            }

            return score;
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }
    }
}
