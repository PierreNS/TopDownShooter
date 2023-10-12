using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private EnemyHealth _health;
        private NavMeshAgent _agent;
        private Rigidbody2D _rigidBody2D;
        private NavMeshPath _path;

        void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _agent = GetComponent<NavMeshAgent>();
            _health = GetComponent<EnemyHealth>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _agent.updatePosition = false;
            _path = new NavMeshPath();
        }

        void Update()
        {
            GetPath();
        }

        void FixedUpdate()
        {
            HandleMovement();
        }

        private void GetPath()
        {
            if(NavMesh.SamplePosition(_target.position, out var hit,1f,NavMesh.AllAreas))
            {
                NavMesh.CalculatePath(transform.position, hit.position, NavMesh.AllAreas, _path);
                _agent.SetPath(_path);
            }
        }

        private void HandleMovement()
        {
            if(_health.IsDead == true) return;

            var newPos = _rigidBody2D.position + (Vector2)_agent.desiredVelocity * Time.fixedDeltaTime;
            NavMesh.SamplePosition(newPos, out var hit,1f,NavMesh.AllAreas);
            _rigidBody2D.MovePosition(hit.position);
            _agent.Warp(_rigidBody2D.position);
        }
    }
}