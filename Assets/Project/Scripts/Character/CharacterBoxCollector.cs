using System.Collections;
using Interfaces;
using UnityEngine;
using View;

namespace Character
{
    public class CharacterBoxCollector : MonoBehaviour
    {
        [SerializeField] private UIView uiView;
        [SerializeField] private CharacterAnimator characterAnimator;
        [SerializeField] private int timeBoxCollection;
        
        private Coroutine _timerCoroutine;
        private IInteractive _box;
        
        private void StartCollect()
        {
            if (_timerCoroutine == null)
            {
                _timerCoroutine = StartCoroutine(TimerCollection());
                characterAnimator.Collect();
                uiView.PanelCollect(true);
            }
        }

        private void Interaction()
        { 
            _box.Interactive();
        }
        
        private IEnumerator TimerCollection()
        {
            var current = 0f;

            while (current < 3)
            {
                yield return new WaitForSeconds(0.1f);
                current += 0.1f;
                
                uiView.SetAmountCollect(current, timeBoxCollection);
            }

            Interaction();
            uiView.PanelCollect(false);
            characterAnimator.StopCollect();
            
            _timerCoroutine = null;
            _box = null;
        }
        
        public void StopCollect()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
                characterAnimator.StopCollect();
                uiView.PanelCollect(false);
                
                _timerCoroutine = null;
                _box = null;
            }
        }
        
        public void Collect(IInteractive obj)
        {
            _box = obj;
            StartCollect();
        }
    }
}