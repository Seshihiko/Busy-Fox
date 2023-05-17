using UnityEngine;
using View;

namespace Scene
{
    public class LevelPresender : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private BoxContainer boxContainer;
        [SerializeField] private UIView uiView;

        public bool isPause = true;
        
        private void Start()
        {
            timer.TimeUpdate.AddListener(SetTimeGameToView);
            boxContainer.AllBoxesAreAssembled.AddListener(GameWins);
            boxContainer.WrongSequence.AddListener(GameOver);
        }

        private void SetTimeGameToView(float value)
        {
            uiView.SetTimerText(value);
        }

        private void StopGame()
        {
            isPause = true;
            timer.StopTimer();
        }

        private void GameWins()
        {
            StopGame();
            uiView.OpenPanelWins(timer.TimeGame);
        }

        private void GameOver()
        {
            StopGame();
            uiView.OpenPanelOver();
        }
        
        public void StartGame()
        {
            isPause = false;
            timer.StartTimer();
        }
    }
}