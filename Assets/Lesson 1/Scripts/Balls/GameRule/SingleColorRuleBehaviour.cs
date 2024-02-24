using System;

namespace HomeTask.Lesson1
{
    internal class SingleColorRuleBehaviour : IRuleBehaviour
    {
        public event Action LooseGame;
        public event Action WinGame;

        private BallType? _ballType;
        private int _singleColorLeftBallsCount;

        public SingleColorRuleBehaviour(int singleColorBallsCount)
        {
            _singleColorLeftBallsCount = singleColorBallsCount;
        }

        public void OnBallClicked(BallComponent ball)
        {
            if (!_ballType.HasValue)
            {
                _ballType = ball.Type;
            }

            if (_ballType != ball.Type)
            {
                LooseGame?.Invoke();
                return;
            }

            _singleColorLeftBallsCount--;

            if (_singleColorLeftBallsCount == 0)
            {
                WinGame?.Invoke();
                return;
            }

        }
    }
}
