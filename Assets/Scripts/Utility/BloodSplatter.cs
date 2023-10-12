using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Utility
{
    class BloodSplatter : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _bloodSplats = new List<Sprite>();
        [SerializeField] private SpriteRenderer _spriteRenderer;

        void Awake()
        {
            var index = Random.Range(0,_bloodSplats.Count);
            _spriteRenderer.sprite = _bloodSplats[index];    
        }
    }
}