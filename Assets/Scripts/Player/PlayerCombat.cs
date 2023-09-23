using TopDownShooter.Managers;
using TopDownShooter.Utility;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.RightMouseButtonClicked += OnRightMouseButtonClicked;
    }

    private void OnRightMouseButtonClicked()
    {
        CrossHair.Instance.ToggleCrosshairLock();
    }
}
