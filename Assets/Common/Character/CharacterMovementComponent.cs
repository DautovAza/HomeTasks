using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace HomeTask.Common
{
    [RequireComponent(typeof(NavMeshAgent))]
    internal class CharacterMovementComponent : MonoBehaviour
    {
        private Camera _camera;
        private NavMeshAgent _agent;
        private GameInputActions _inputActions;

        private void Awake()
        {
            _camera = Camera.main;
            _agent = GetComponent<NavMeshAgent>();
            _inputActions = new GameInputActions();
            _inputActions.Enable();
        }

        private void Start()
        {
            _agent.updateRotation = false;
        }

        private void Update()
        {
            MoveInDirection(_inputActions.GetMovementVector());
            LookAtDirection(GetLookDirection());
        }

        private void MoveInDirection(Vector3 direction)
        {
            _agent.SetDestination(transform.position + direction);
        }

        private void LookAtDirection(Vector3 direction)
        {
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }

        private Vector3 GetLookDirection()
        {
            var mousePosition = Mouse.current.position.ReadValue();

            Vector3 mousePositionInWorldSpace = _camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, _camera.transform.position.y));
            Vector3 direction = mousePositionInWorldSpace - transform.position;
            direction.y = 0f;

            return direction.normalized;
        }
    }
}