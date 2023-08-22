using System;
using UnityEngine;

namespace Game
{
    internal sealed class KeyboardInput : MonoBehaviour
    {
        public event Action<Vector2Int> MovePerformed;
        public event Action<Vector2Int> ActionPerformed;

        private void Update()
        {
            HandleWasd();
            HandleArrows();
        }

        private void HandleWasd()
        {
            var movement = new Vector2Int();

            if (Input.GetKeyUp(KeyCode.W))
            {
                movement.y += 1;
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                movement.y -= 1;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                movement.x += 1;
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                movement.x -= 1;
            }

            if (movement != Vector2Int.zero)
            {
                MovePerformed?.Invoke(movement);
            }
        }

        private void HandleArrows()
        {
            var action = new Vector2Int();
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                action.y += 1;
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                action.y -= 1;
            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                action.x += 1;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                action.x -= 1;
            }

            if (action != Vector2Int.zero)
            {
                ActionPerformed?.Invoke(action);
            }
        }
    }
}