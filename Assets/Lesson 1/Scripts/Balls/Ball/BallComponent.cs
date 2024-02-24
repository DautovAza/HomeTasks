using System;
using UniRx;
using UnityEngine;

namespace HomeTask.Lesson1
{
    internal partial class BallComponent : MonoBehaviour
    {
        [SerializeField]
        private BallType _ballType;

        public BallType Type => _ballType;

        private ISubject<BallComponent> _onCkickObservable = new Subject<BallComponent>();

        public IObservable<BallComponent> OnCkickObservable => _onCkickObservable;

        private void OnMouseDown()
        {
            _onCkickObservable.OnNext(this);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

    }
}
