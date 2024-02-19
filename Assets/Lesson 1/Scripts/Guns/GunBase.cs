using UnityEngine;

namespace HomeTask.Lesson1
{
    internal abstract class GunBase : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;

        public abstract bool CanShoot { get; }

        public abstract void Shoot();

        protected Bullet CreateBullet(Vector3 position)
        {
            return Instantiate(_bulletPrefab, position, Quaternion.identity);
        }
    }
}