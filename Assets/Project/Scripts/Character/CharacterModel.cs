using UnityEngine;

namespace Character
{
    public class CharacterModel : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        public float Speed => speed;
    }
}