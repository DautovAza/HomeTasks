using System;
using UnityEngine;

namespace HomeTask.Lesson1
{
    public class RaitingModifireComponent : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private PlayerRaitingComponent _raitingComponent;

        [SerializeField]
        private bool _isIncreaseRating;

        private void Awake()
        {
            if (_raitingComponent is null)
            {
                throw new NullReferenceException($"Отсутвует ссылка на компонент {nameof(PlayerRaitingComponent)} у объекта {name}!");
            }
        }

        public void Interract()
        {
            if (_isIncreaseRating)
            {
                _raitingComponent.IncreaseRaiting();
            }
            else
            {
                _raitingComponent.DecreaseRaiting();
            }
        }
    }
}
