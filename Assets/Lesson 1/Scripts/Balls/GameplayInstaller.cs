using UnityEngine;

namespace HomeTask.Lesson1
{
    internal class GameplayInstaller : MonoBehaviour
    {
        [SerializeField]
        private BallGameSettingsSO _settings;

        [SerializeField]
        private GameTypeSelector _gameTypeSelector;

        private Level _level;
        private BallSpawner _spawner;

        private void Awake()
        {
            _spawner = new BallSpawner(_settings.BallsSettings);
        }

        private void OnEnable()
        {
            _gameTypeSelector.SingleColorGameSelected += OnSingleColorGameSelected;
            _gameTypeSelector.AllBallsGameSelected += OnAllBallsGameSelected;
        }

        private void OnDisable()
        {
            _gameTypeSelector.SingleColorGameSelected -= OnSingleColorGameSelected;
            _gameTypeSelector.AllBallsGameSelected -= OnAllBallsGameSelected;
        }

        private void StartGame(IRuleBehaviour ruleBehaviour)
        {
            _gameTypeSelector.HideGameTypeSelectPanel();

            var balls = _spawner.Spawn();
            var ballController = new BallsController(balls);
            _level = new Level(ballController, ruleBehaviour);
            _level.OnGameEnd += OnGameEnd;
        }

        private void OnGameEnd()
        {
            _level.OnGameEnd -= OnGameEnd;
            _gameTypeSelector.ShowGameTypeSelectPanel();
        }

        private void OnAllBallsGameSelected()
        {
            BallsSettings ballsSettings = _settings.BallsSettings;
            int ballsCount = ballsSettings.SingleColorBallsCount * ballsSettings.BallsPrefabs.Length;

            StartGame(new AllBallsRuleBehaviour(ballsCount));
        }

        private void OnSingleColorGameSelected()
        {
            StartGame(new SingleColorRuleBehaviour(_settings.BallsSettings.SingleColorBallsCount));
        }
    }
}
