using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Managers;
using TopDownShooter.Utility;

namespace TopDownShooter.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _distanceFromCamera = 10;
        [SerializeField] private float _lookAtDeadZone = 0.5f;
        [SerializeField] private Transform _spriteTransform;
        private Vector2 _moveDirection;
        private Vector2 _mousePosition;
        private Rigidbody2D _rigidbody2D;
        private Camera _camera;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _camera = Camera.main;
        }

        private void Update()
        {
            HandleInput();
            HandleRotation();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleInput()
        {
            _moveDirection = InputManager.Instance.MoveDirection;
            _mousePosition = CrossHair.Instance.transform.position;
        }

        private void HandleRotation()
        {
            var crosshairPos = CrossHair.Instance.transform.position;
            
            if (Vector2.Distance(new Vector2(transform.position.x,transform.position.y), 
                    new Vector2(crosshairPos.x,crosshairPos.y)) < _lookAtDeadZone) return;

            var lookDirection = (_mousePosition - (Vector2)transform.position).normalized;
            transform.up = lookDirection;
        }

        private void HandleMovement()
        {
            var newPos = _rigidbody2D.position += (_moveDirection * (_moveSpeed * Time.fixedDeltaTime));
            _rigidbody2D.MovePosition(newPos);
        }
    }
}