using System.Collections.Generic;
using Interactive.Box;
using UnityEngine;
using UnityEngine.Events;

namespace Scene
{
    public class BoxContainer : MonoBehaviour
    {
        [SerializeField] private List<Box> boxes;
        
        private int _indexOfLastBox = 0;

        public UnityEvent AllBoxesAreAssembled;
        public UnityEvent WrongSequence;
        
        private void Start()
        {
            foreach (var box in boxes)
            {
                box.SetConteiner(this);
            }
        }
        
        public void RemoveBox(Box box)
        {
            boxes.Remove(box);
            
            if (_indexOfLastBox + 1 == box.Index)
                _indexOfLastBox = box.Index;
            else
            {
                WrongSequence?.Invoke();
                return;
            }

            if (boxes.Count == 0)
            {
                AllBoxesAreAssembled?.Invoke();
            }
        }
    }
}