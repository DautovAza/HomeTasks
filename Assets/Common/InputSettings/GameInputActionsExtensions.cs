using UnityEngine;
using UnityEngine.InputSystem;

namespace HomeTask.Common
{
    public static class GameInputActionsExtensions
    {
        public static Vector3 GetMovementVector(this GameInputActions inputActions)
        {
            var movement2D = inputActions.GamePlay.Movement.ReadValue<Vector2>();
            return new Vector3(movement2D.x, 0, movement2D.y);
        }

        public static InputAction GetShootAction(this GameInputActions inputActions) =>
            inputActions.GamePlay.Shoot;
    }
}