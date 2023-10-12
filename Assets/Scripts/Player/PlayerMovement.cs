using UnityEngine;
using TopDownShooter.Managers;

namespace TopDownShooter.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _lookAtDeadZone = 0.5f;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private Vector2 _moveDirection;
        private Vector2 _mousePosition;
        private Rigidbody2D _rigidbody2D;
        private Animator[] _animators;
        private Camera _camera;

        private Vector3 _velocity;
        private Vector3 _lastPosition;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animators = GetComponentsInChildren<Animator>();
            _camera = Camera.main;
        }

        private void Update()
        {
            HandleInput();
            HandleRotation();
            HandleAnimation();
        }


        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleInput()
        {
            _moveDirection = InputManager.Instance.MoveDirection;
            _mousePosition = InputManager.Instance.ScreenSpaceMousePosition;
        }

        private void HandleRotation()
        {
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
                    new Vector2(_mousePosition.x, _mousePosition.y)) < _lookAtDeadZone) return;

            _spriteRenderer.flipX = _mousePosition.x > transform.position.x ? true : false;

            // if (_mousePosition.x > transform.position.x)
            //     _spriteRenderer.flipX = true;
            // else
            //     _spriteRenderer.flipX = false;
        }

        private void HandleAnimation()
        {
            if (_velocity.magnitude > 0.05)
            {
                //We be running...
                foreach (var animator in _animators)
                {
                    animator.Play("Walk");
                }
            }
            else
            {
                //We be doing something else...
                foreach (var animator in _animators)
                {
                    animator.Play("Idle");
                }
            }
        }

        private void HandleMovement()
        {
            _velocity = transform.position - _lastPosition;

            var newPos = _rigidbody2D.position + (_moveDirection * (_moveSpeed * Time.fixedDeltaTime));
            _rigidbody2D.MovePosition(newPos);

            _lastPosition = transform.position;
        }
    }
}