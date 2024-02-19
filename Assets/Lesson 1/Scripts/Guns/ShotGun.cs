using System.Collections.Generic;
using UnityEngine;

namespace HomeTask.Lesson1
{
    internal class ShotGun : GunBase
    {
        [SerializeField] private int _bulletsCount = 30;
        [SerializeField] private List<Transform> _shootPoints;

        private int _shootsLeft;

        private void Awake()
        {
            _shootsLeft = _bulletsCount;
        }

        public override bool CanShoot => _shootsLeft > 0;

        public override void Shoot()
        {
            foreach (var shootPoint in _shootPoints)
            {
                if (_shootsLeft <= 0) return;

                var bullet = CreateBullet(shootPoint.position);
                bullet.MoveInDirection(shootPoint.forward);
                _shootsLeft--;
            }
        }
    }
}