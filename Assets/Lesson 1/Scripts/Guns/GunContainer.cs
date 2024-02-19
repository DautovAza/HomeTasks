using UnityEngine;

namespace HomeTask.Lesson1
{
    [RequireComponent(typeof(Collider))]
    internal class GunContainer : MonoBehaviour
    {
        [SerializeField]
        private GunBase _gunPrefab;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterGunController gunController))
            {
                gunController.EquipGun(GetGun());
            }
        }

        private GunBase GetGun() =>
            Instantiate(_gunPrefab);
    }
}