using UnityEngine;

namespace HomeTask.Lesson1
{
    internal class MachineGun : GunBase
    {
        [SerializeField] private Transform _shootPoint;

        public override bool CanShoot => true;

        public override void Shoot()
        {
            var bullet = CreateBullet(_shootPoint.position);
            bullet.MoveInDirection(transform.forward);
        }
    }
}