using UnityEngine;

namespace View
{
    public class SceneView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleClic;

        public void PlayParticleClic(Vector3 position)
        {
            _particleClic.transform.position = position;
            _particleClic.Play();
        }
    }
}