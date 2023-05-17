using System.Collections;
using Architecture;
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
        private CoroutineObject _coroutineMovement;

        [HideInInspector] public UnityEvent<bool> IsWalking;

        private void Awake()
        {
            IsWalking.AddListener(characterAnimator.Walking);
            _coroutineMovement = new CoroutineObject(this, CoroutineMovement);
        }

        private IEnumerator CoroutineMovement()
        {
            while (true)
            {
                navMeshAgent.SetDestination(_target);

                var distance = Vector3.Distance(transform.position, _target);
                
                if (distance <= stopingDistance)
                {
                    ClearTarget();
                }
                
                IsWalking.Invoke(!navMeshAgent.isStopped);
                yield return null;
            }
        }

        public void SetSpeed(float speed)
        {
            navMeshAgent.speed = speed;
        }
        
        public void SetTarget(Vector3 target)
        {
            _target = target;
            
            navMeshAgent.Resume();
            _coroutineMovement.Start();
        }

        public void ClearTarget()
        {
            navMeshAgent.Stop();
            _coroutineMovement.Stop();
        }
    }
}