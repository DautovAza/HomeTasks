using System;
using System.Linq;
using System.Collections.Generic;
using UniRx;

namespace HomeTask.Lesson1
{
    internal class BallsController : IDisposable
    {
        public event Action<BallComponent> BallClicked;

        private Dictionary<BallComponent, IDisposable> _ballsClickEventsMap;

        public BallsController(IEnumerable<BallComponent> balls)
        {
            _ballsClickEventsMap = balls
                .ToDictionary(ball => ball, action => action.OnCkickObservable.Subscribe(OnBallClicked));
        }

        private void OnBallClicked(BallComponent ball)
        {
            BallClicked?.Invoke(ball);
            _ballsClickEventsMap.Remove(ball);
            ball.Destroy();
        }

        public void Dispose()
        {
            foreach (var ball in _ballsClickEventsMap.Keys.ToList())
            {
                _ballsClickEventsMap[ball].Dispose();
                _ballsClickEventsMap[ball] = null;
                ball.Destroy();
            }
        }
    }
}
