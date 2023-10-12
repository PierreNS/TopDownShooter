using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Interfaces;
using UnityEngine;

public class TestHit : MonoBehaviour, IShootable
{
    public void Hit()
    {
        Debug.Log("Auch that hurt you fucker!");
    }
}
