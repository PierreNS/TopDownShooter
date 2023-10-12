using System;
using TopDownShooter.Interfaces;
using TopDownShooter.Managers;
using TopDownShooter.Utility;
using UnityEngine;

namespace TopDownShooter.Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private LayerMask _shootingMask;
        [SerializeField] private float _shootingRange = 10f;
        [SerializeField] private float _rateOfFire = 1f;
        [SerializeField] private Transform _gunTransform;

        private SpriteRenderer _gunSpriteRenderer;
        private float _currentFireTime = 0;

        private Vector3 _mousePos;

        private void Awake()
        {
            _gunSpriteRenderer = _gunTransform.GetComponentInChildren<SpriteRenderer>();
        }

        private void Start()
        {
            InputManager.Instance.RightMouseButtonClicked += OnRightMouseButtonClicked;
            InputManager.Instance.LeftMouseButtonClicked += OnLeftMouseButtonClicked;
        }

        private void OnLeftMouseButtonClicked()
        {
            if (_currentFireTime < Time.time)
            {
                _currentFireTime = Time.time + _rateOfFire;

                var mousePos = InputManager.Instance.ScreenSpaceMousePosition;
                var aimPos = new Vector3(mousePos.x, mousePos.y, 0);

                var hit2D = Physics2D.Raycast(_gunTransform.position, _gunTransform.right,
                    _shootingRange, _shootingMask);

                Debug.DrawRay(_gunTransform.position, _gunTransform.right * _shootingRange, Color.blue, 5);

                if (hit2D.collider != null)
                {
                    Debug.Log($"We hit: {hit2D.collider.name}");
                    if (hit2D.collider.TryGetComponent<IShootable>(out var shootable) == true)
                    {
                        shootable.Hit();
                    }
                }
            }
        }

        private void OnRightMouseButtonClicked()
        {
        }

        void Update()
        {
            HandleGunRotation();
        }

        private void HandleGunRotation()
        {
            Vector3 mousePos = InputManager.Instance.MousePosition;
            mousePos.z = 20f;

            var objectPos = Camera.main.WorldToScreenPoint(_gunTransform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            _gunTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            _gunSpriteRenderer.flipY = mousePos.x > transform.position.x ? false : true;
        }
    }
}