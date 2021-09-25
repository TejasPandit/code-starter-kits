using System.Collections.Generic;

namespace BowlingBall
{
    public class Game : IGame
    {

        private List<int> _rolls = new List<int>(21);
        private int _currentRole = 0;
        public int score { get; set; }


        public Game()
        {
            for (int i = 0; i < 22; i++)
            {
                _rolls.Add(0);
            }
        }

        public void Roll(int pinsHit)
        {
            _rolls[_currentRole++] = pinsHit;
        }

        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    //strike 

                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    //spare

                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += NormalFrameBonus(frameIndex);
                    frameIndex += 2;
                }

            }

            return score;
        }

        #region private methods

        private int NormalFrameBonus(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1]; ;
        }

        private int SpareBonus(int frameIndex)
        {
            return _rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }

        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }

        #endregion private methods
    }
}
