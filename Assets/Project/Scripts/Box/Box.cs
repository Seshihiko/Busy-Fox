using Interfaces;
using Scene;
using UnityEngine;
using UnityEngine.UI;

namespace Interactive.Box
{
    public class Box : MonoBehaviour, IInteractive
    {
        [SerializeField] private Text indexText;
        [SerializeField] private ParticleSystem particleCollect;
        [SerializeField] private int index;

        private BoxContainer _boxContainer;

        public int Index => index;

        private void Start()
        {
            indexText.text = $"{index}";
        }

        public void SetConteiner(BoxContainer container)
        {
            _boxContainer = container;
        }

        public void Interactive()
        {
            _boxContainer.RemoveBox(this);
            Instantiate(particleCollect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}