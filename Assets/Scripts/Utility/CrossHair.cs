using UnityEngine;
using TopDownShooter.Managers;

namespace TopDownShooter.Utility
{
    public class CrossHair : MonoBehaviour
    {
        public static CrossHair Instance;

        [SerializeField] private float _distanceFromCamera = 10;
        
        private Camera _camera;
        private bool _locked = false;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;

            if (Instance != this)
                Destroy(this);
            
            _camera = Camera.main;
            Cursor.visible = false;
        }

        private void LateUpdate()
        {
            if (_locked == true) return;
            
            var mousePos = InputManager.Instance.MousePosition;
            var newPos = _camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, _distanceFromCamera));
            transform.position = newPos;
        }

        public void ToggleCrosshairLock()
        {
            _locked = !_locked;
        }
    }
}