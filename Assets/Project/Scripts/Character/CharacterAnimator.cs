using UnityEngine;

namespace Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        public void Walking(bool isWalking)
        {
            animator.SetBool("Walking", isWalking);   
        }

        public void Collect()
        {
            animator.SetTrigger("Collect"); 
        }
        
        public void StopCollect()
        {
            animator.SetTrigger("StopCollect"); 
        }
    }
}