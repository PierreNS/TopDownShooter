using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDownShooter.Managers
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;

        private Vector2 _moveDirection;
        private Vector2 _mousePosition;
        public Vector2 MoveDirection => _moveDirection;
        public Vector2 MousePosition => _mousePosition;

        public event Action RightMouseButtonClicked;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;

            if (Instance != this)
                Destroy(this);

            Cursor.visible = false;
        }

        public void OnMovementDirection(InputValue value)
        {
            _moveDirection = value.Get<Vector2>();
        }

        public void OnMousePosition(InputValue value)
        {
            _mousePosition = value.Get<Vector2>();
        }

        public void OnRightMouseButton(InputValue value)
        {
            RightMouseButtonClicked?.Invoke();
        }
    }
}