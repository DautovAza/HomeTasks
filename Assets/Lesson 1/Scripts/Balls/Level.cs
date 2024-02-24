using System;
using UnityEngine;

namespace HomeTask.Lesson1
{
    internal class Level
    {
        public event Action OnGameEnd;

        private BallsController _ballController;
        private IRuleBehaviour _ruleBehaviour;

        public Level(BallsController ballController, IRuleBehaviour ruleBehaviour)
        {
            _ballController = ballController;
            _ruleBehaviour = ruleBehaviour;
            _ballController.BallClicked += _ruleBehaviour.OnBallClicked;
            _ruleBehaviour.WinGame += OnWin;
            _ruleBehaviour.LooseGame += OnLoose;
        }

        private void OnWin()
        {
            Debug.Log("Победа!");
            EndGame();
        }
        private void OnLoose()
        {
            Debug.Log("Поражение!");
            EndGame();
        }

        private void EndGame()
        {
            _ruleBehaviour.WinGame -= OnWin;
            _ruleBehaviour.LooseGame -= OnLoose;
            _ballController.BallClicked -= _ruleBehaviour.OnBallClicked;
            _ballController.Dispose();
            OnGameEnd?.Invoke();
        }
    }
}
