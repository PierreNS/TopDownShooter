using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDownShooter.Managers
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;

        private Camera _camera;

        private Vector2 _moveDirection;
        private Vector2 _mousePosition;
        private Vector2 _screenSpaceMousePosition;
        public Vector2 MoveDirection => _moveDirection;
        public Vector2 MousePosition => _mousePosition;
        public Vector2 ScreenSpaceMousePosition => _screenSpaceMousePosition;

        public event Action RightMouseButtonClicked;
        public event Action LeftMouseButtonClicked;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;

            if (Instance != this)
                Destroy(this);

            Cursor.visible = false;

            _camera = Camera.main;
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

        private void Update()
        {
            if (Mouse.current.leftButton.isPressed == true)
            {
                LeftMouseButtonClicked?.Invoke();
            }

            _screenSpaceMousePosition = _camera.ScreenToWorldPoint(new Vector3(_mousePosition.x, _mousePosition.y, 20));
        }
    }
}