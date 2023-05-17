using UnityEngine;
using UnityEngine.Events;

namespace Scene
{
    public class Timer : MonoBehaviour
    {
        private float _timeGame;
        private bool _isTimer;

        public float TimeGame => _timeGame;
        public UnityEvent<float> TimeUpdate;

        private void Update()
        {
            if(!_isTimer) return;
            
            _timeGame += Time.deltaTime;
            TimeUpdate?.Invoke(_timeGame);
        }
        
        public void StartTimer()
        {
            _isTimer = true;
        }

        public void StopTimer()
        {
            _isTimer = false;
        }
    }
}