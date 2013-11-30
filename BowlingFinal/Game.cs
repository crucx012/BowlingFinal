using System.Collections.Generic;

namespace BowlingFinal
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] += pins;
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfTheBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            return score;
        }

        public int[] ScoreByFrames()
        {
            var score = new int[10];
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
                if (IsStrike(frameIndex))
                {
                    score[frame] = 10 + StrikeBonus(frameIndex) + LatestScore(frame, score);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score[frame] = 10 + SpareBonus(frameIndex) + LatestScore(frame, score);
                    frameIndex += 2;
                }
                else
                {
                    score[frame] = SumOfTheBallsInFrame(frameIndex) + LatestScore(frame, score);
                    frameIndex += 2;
                }

            return score;
        }

        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }

        private int StrikeBonus(int frameIndex)
        {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }

        private bool IsSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }

        private int SpareBonus(int frameIndex)
        {
            return _rolls[frameIndex + 2];
        }

        private int SumOfTheBallsInFrame(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        private int LatestScore(int frame, IList<int> score)
        {
            return frame > 0 ? score[frame - 1] : 0;
        }
    }
}
