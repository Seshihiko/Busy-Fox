using System;
using System.Collections;
using Architecture;
using Interfaces;
using UnityEngine;
using View;

namespace Character
{
    public class CharacterBoxCollector : MonoBehaviour
    {
        [SerializeField] private UIView uiView;
        [SerializeField] private CharacterAnimator characterAnimator;
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private int timeBoxCollection;
        
        private CoroutineObject _timerCoroutine;
        private IInteractive _box;

        private void Awake()
        {
            _timerCoroutine = new CoroutineObject(this, TimerCollection);
        }

        private void StartCollect()
        {
            characterMovement.ClearTarget();
            _timerCoroutine.Start();
            characterAnimator.Collect();
            uiView.PanelCollect(true);
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
            
            _box = null;
        }
        
        public void StopCollect()
        {
            if(!_timerCoroutine.IsProcessing)
                return;
                
            _timerCoroutine.Stop();
            uiView.PanelCollect(false);
            characterAnimator.StopCollect();
            
            _box = null;
        }
        
        public void Collect(IInteractive obj)
        {
            _box = obj;
            StartCollect();
        }
    }
}