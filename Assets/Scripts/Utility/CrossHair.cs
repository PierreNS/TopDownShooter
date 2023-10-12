using UnityEngine;
using TopDownShooter.Managers;

namespace TopDownShooter.Utility
{
    public class CrossHair : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            Cursor.visible = false;
        }

        private void FixedUpdate()
        {
            var mousePos = InputManager.Instance.MousePosition;
            var pos = _camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 20));

            transform.position = pos;
        }
    }
}