using TopDownShooter.Interfaces;
using UnityEngine;

namespace TopDownShooter.Enemy
{
    public class EnemyHealth : MonoBehaviour, IShootable
    {
        private SpriteRenderer _spriteRenderer;
        private Collider2D[] _colliders;
        private Animator _animator;

        public bool IsDead {get; private set;}

        void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _colliders = GetComponentsInChildren<Collider2D>();
            _animator = GetComponentInChildren<Animator>();
            IsDead = false;
        }

        public void Hit()
        {
            IsDead = true;
            _animator.Play("Dead");
            foreach (var coll in _colliders)
            {
                coll.enabled = false;
            }
        }
    }
}