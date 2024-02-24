using System;

namespace HomeTask.Lesson1
{
    internal interface IRuleBehaviour
    {
        public event Action LooseGame;
        public event Action WinGame;
        void OnBallClicked(BallComponent ball);
    }
}
