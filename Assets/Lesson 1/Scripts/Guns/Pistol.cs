using UnityEngine;

namespace HomeTask.Lesson1
{
    internal class Pistol : GunBase
    {
        [SerializeField] private int _bulletsCount = 10;
        [SerializeField] private Transform _shootPoint;

        private int _shootsLeft;

        private void Awake()
        {
            _shootsLeft = _bulletsCount;
        }

        public override bool CanShoot => _shootsLeft > 0;

        public override void Shoot()
        {
            var bullet = CreateBullet(_shootPoint.position);
            bullet.MoveInDirection(transform.forward);
            _shootsLeft--;
        }
    }
}