using System;
using System.Collections;
using Architecture;
using UnityEngine;
using UnityEngine.Events;

namespace Scene
{
    public class Timer : MonoBehaviour
    {
        private float _timeGame;
        private CoroutineObject _coroutineTimer;
        
        public UnityEvent<float> TimeUpdate;
        
        public float TimeGame => _timeGame;
        public void StartTimer() => _coroutineTimer.Start();
        public void StopTimer() => _coroutineTimer.Stop();

        private void Awake()
        {
            _coroutineTimer = new CoroutineObject(this, CoroutineTimer);
        }

        private IEnumerator CoroutineTimer()
        {
            while (true)
            {
                _timeGame += Time.deltaTime;
                TimeUpdate?.Invoke(_timeGame);
                yield return null;
            }
        }
    }
}