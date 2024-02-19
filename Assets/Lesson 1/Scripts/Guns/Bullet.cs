using System;
using UniRx;
using UnityEngine;
using UniRx.Triggers;

namespace HomeTask.Lesson1
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        [Min(.1f)]
        private float _speed;

        [SerializeField]
        [Range(1f, 10)]
        private float _maxLifeTime;

        public void MoveInDirection(Vector3 direction)
        {
            transform.rotation = Quaternion.LookRotation(direction);

            Observable.Timer(TimeSpan.FromSeconds(_maxLifeTime))
                  .Subscribe(_ => DestroyBullet())
                  .AddTo(this);

            this.FixedUpdateAsObservable()
                    .Subscribe(_ => MoveForward())
                    .AddTo(this);
        }

        private void OnTriggerEnter(Collider other) =>
            DestroyBullet();

        private void MoveForward() =>
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        private void DestroyBullet() =>
            Destroy(gameObject);

    }
}