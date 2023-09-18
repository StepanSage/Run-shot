using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Scripts.UI 
{
    public class TextFate : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private Color _startColot;
        private Color _endColot;
       

        void Start()
        {
            _startColot = new Vector4(_text.color.r, _text.color.g, _text.color.b, 1);
            _endColot = new Vector4(_text.color.r, _text.color.g, _text.color.b, 0);
            Fade();
        }

        
        void Update()
        {
            
            
        }

        private void Fade()
        {           
            Sequence sequence = DOTween.Sequence();           
            sequence.Append(_text.DOColor(_endColot, 1.5f).SetEase(Ease.Linear));          
            sequence.Append(_text.DOColor(_startColot, 1.5f).SetEase(Ease.Linear));
            sequence.SetLoops(-1);
        }
       
    }
}

