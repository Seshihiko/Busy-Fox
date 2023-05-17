using Interfaces;
using UnityEngine;

namespace Character
{
    public class CharacterPresender : MonoBehaviour
    {
        [SerializeField] private CharacterModel model;
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private CharacterBoxCollector characterBoxCollector;
        [SerializeField] private float distanseInteractive;

        private void Start()
        {
            characterMovement.SetSpeed(model.Speed);
        }

        public void SetMoveTarget(Vector3 targetPosition)
        {
            characterMovement.SetTarget(targetPosition);
            characterBoxCollector.StopCollect();
        }
        
        public bool IsPossibleToCollect(IInteractive obj)
        {
            var distance = Vector3.Distance(transform.position, obj.GetTransform().position);

            if (distance <= distanseInteractive)
            {
                characterMovement.ClearTarget();
                characterBoxCollector.Collect(obj);
                return true;
            }

            return false;
        }
    }
}