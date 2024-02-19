using UnityEngine;
using UnityEngine.InputSystem;
using HomeTask.Common;

namespace HomeTask.Lesson1
{
    internal class CharacterGunController : MonoBehaviour
    {
        [SerializeField] private GunBase _gun;
        [SerializeField] private Transform _gunSlotTransform;

        private GameInputActions _inputActions;

        private void OnEnable()
        {
            _inputActions = new GameInputActions();
            _inputActions.GetShootAction().performed += Shoot;
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.GetShootAction().performed -= Shoot;
        }

        public void EquipGun(GunBase gun)
        {
            DropGun();
            AttachGunTransform(gun.transform);
            _gun = gun;
            Debug.Log("Подобрал оружие " + gun.GetType().Name);
        }

        private void Shoot(InputAction.CallbackContext context)
        {
            if (_gun is null) return;

            if (_gun.CanShoot)
            {
                _gun.Shoot();
            }
            else
            {
                Debug.Log("Нет патронов!");
            }

        }

        private void AttachGunTransform(Transform gunTransform)
        {
            gunTransform.SetParent(_gunSlotTransform, false);
            gunTransform.localPosition = Vector3.zero;
        }

        private void DropGun()
        {
            if (_gun is null) return;

            Destroy(_gun.gameObject);
            _gun = null;
        }
    }
}
