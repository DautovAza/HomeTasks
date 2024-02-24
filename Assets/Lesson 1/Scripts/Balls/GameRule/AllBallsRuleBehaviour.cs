using System;

namespace HomeTask.Lesson1
{
    internal class AllBallsRuleBehaviour : IRuleBehaviour
    {
        public event Action LooseGame;
        public event Action WinGame;

        private int _ballsLEftCount;

        public AllBallsRuleBehaviour(int ballsCount)
        {
            _ballsLEftCount = ballsCount;
        }

        public void OnBallClicked(BallComponent ball)
        {
            _ballsLEftCount--;

            if (_ballsLEftCount == 0)
            {
                WinGame?.Invoke();
            }
        }
    }
}
