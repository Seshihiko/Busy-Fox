using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private CharacterAnimator characterAnimator;
        [SerializeField] private float stopingDistance;

        private Vector3 _target;

        [HideInInspector] public UnityEvent<bool> IsWalking;

        private void Start()
        {
            IsWalking.AddListener(characterAnimator.Walking);
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            if (_target != Vector3.zero)
            {
                navMeshAgent.SetDestination(_target);

                var distance = Vector3.Distance(transform.position, _target);
                
                if (distance <= stopingDistance)
                {
                    ClearTarget();
                }
            }

            IsWalking.Invoke(_target != Vector3.zero);
        }

        public void SetSpeed(float speed)
        {
            navMeshAgent.speed = speed;
        }
        
        public void SetTarget(Vector3 target)
        {
            _target = target;
        }

        public void ClearTarget()
        {
            _target = Vector3.zero;
        }
    }
}