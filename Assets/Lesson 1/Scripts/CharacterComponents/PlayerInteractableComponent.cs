using HomeTask.Common;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HomeTask.Lesson1
{
    internal class PlayerInteractableComponent : MonoBehaviour
    {
        [SerializeField]
        private float _interactionRadius = 1.5f;
        private GameInputActions _inputActions;

     
        private void OnEnable()
        {
            _inputActions = new GameInputActions();
            _inputActions.GamePlay.Interaction.performed += OnInteractionClicked;
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.GamePlay.Interaction.performed -= OnInteractionClicked;
        }

        private void OnInteractionClicked(InputAction.CallbackContext obj)
        {
            TryInteract();
        }

        private bool TryInteract()
        {
            var collisions = Physics.OverlapSphere(transform.position, _interactionRadius);

            var interractionTargetObject = collisions
                .FirstOrDefault(col => col.TryGetComponent<IInteractable>(out _));

            if (interractionTargetObject.TryGetComponent(out IInteractable interactableComponent))
            {
                interactableComponent.Interract();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
