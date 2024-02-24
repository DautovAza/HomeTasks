using System;
using UnityEngine;
using UnityEngine.UI;

namespace HomeTask.Lesson1
{
    internal class GameTypeSelector : MonoBehaviour
    {
        public event Action SingleColorGameSelected;
        public event Action AllBallsGameSelected;

        [SerializeField]
        private GameObject _gameTypeSelectorPanel;

        [SerializeField]
        private Button _allBallsGameButton;

        [SerializeField]
        private Button _singleColorGameButton;

        private bool IsActive => gameObject.active;

        private void OnEnable()
        {
            _allBallsGameButton.onClick.AddListener(OnAllBallsButtonClicked);
            _singleColorGameButton.onClick.AddListener(OnSingleColorButtonClicked);
        }

        private void OnDisable()
        {
            _allBallsGameButton.onClick.RemoveListener(OnAllBallsButtonClicked);
            _singleColorGameButton.onClick.RemoveListener(OnSingleColorButtonClicked);
        }

        private void OnSingleColorButtonClicked()
        {
            if (!IsActive) return;

            Debug.Log("Выбран режим одного цвета.");
            SingleColorGameSelected?.Invoke();
        }

        private void OnAllBallsButtonClicked()
        {
            if (!IsActive) return;

            Debug.Log("Выбран режим всех шаров.");
            AllBallsGameSelected?.Invoke();
        }



        public void ShowGameTypeSelectPanel()
        {
            gameObject.SetActive(true);
        }

        public void HideGameTypeSelectPanel()
        {
            gameObject.SetActive(false);
        }

    }
}
