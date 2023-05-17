using Architecture;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private Text timerGameText;
        [SerializeField] private Text timerWinsText;
        [SerializeField] private Image selectionScale;
        [SerializeField] private Image panelCollect;
        [SerializeField] private Image panelGame;
        [SerializeField] private Image panelWins;
        [SerializeField] private Image panelOver;

        public void SetTimerText(float timeGame)
        {
            timerGameText.text = TimeConverter.Convert(timeGame);
        }
        
        public void PanelCollect(bool isOpen)
        {
            panelCollect.gameObject.SetActive(isOpen);
        }

        public void SetAmountCollect(float current, float value)
        {
            selectionScale.fillAmount = current / value;
        }

        public void OpenPanelWins(float timeGame)
        {
            panelGame.gameObject.SetActive(false);
            panelWins.gameObject.SetActive(true);
            
            timerWinsText.text = TimeConverter.Convert(timeGame);
        }

        public void OpenPanelOver()
        {
            panelGame.gameObject.SetActive(false);
            panelOver.gameObject.SetActive(true);
        }
    }
}