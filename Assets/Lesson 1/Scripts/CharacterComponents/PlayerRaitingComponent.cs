using System;
using UnityEngine;

namespace HomeTask.Lesson1
{
    internal class PlayerRaitingComponent : MonoBehaviour
    {
        public event Action<int> RaitingChanged;

        [SerializeField, Range(2,10)]
        private int _maxRaiting=2;
        private int _raitingValue;

        public void IncreaseRaiting()
        {
            _raitingValue = Math.Min(_raitingValue + 1, _maxRaiting);
            RaitingChanged?.Invoke(_raitingValue);
            Debug.Log("Рейтинг повысился! Текущий рейтинг: " + _raitingValue);
        }

        public void DecreaseRaiting()
        {
            _raitingValue = Math.Max(_raitingValue - 1,0);
            RaitingChanged?.Invoke(_raitingValue);
            Debug.Log("Рейтинг понизился! Текущий рейтинг: " + _raitingValue);
        }
    }
}
