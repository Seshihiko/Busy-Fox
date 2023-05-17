using Character;
using Interfaces;
using Scene;
using UnityEngine;
using UnityEngine.SceneManagement;
using View;

namespace Inputs
{
    public class InputCather : MonoBehaviour
    {
        [SerializeField] private CharacterPresender characterPresender;
        [SerializeField] private LevelPresender levelPresender;
        [SerializeField] private SceneView sceneView;

        private Controls _controls;
        
        private void Awake()
        {
            _controls = new Controls();
            Init();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void Init()
        {
            _controls.ControlActions.LeftMouseButton.performed += context => ClicLeftButtonMouse();
        }

        private void ClicLeftButtonMouse()
        {
            if(levelPresender.isPause)
                return;
                
            var ray = Camera.main.ScreenPointToRay(_controls.ControlActions.MousePosition.ReadValue<Vector2>());

            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.TryGetComponent<IInteractive>(out var obj) && characterPresender.IsPossibleToCollect(obj))
                {
                    return;
                }
                
                characterPresender.SetMoveTarget(hit.point);
                sceneView.PlayParticleClic(hit.point);
            }
        }

        public void StartGame()
        {
            levelPresender.StartGame();
        }
        
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}