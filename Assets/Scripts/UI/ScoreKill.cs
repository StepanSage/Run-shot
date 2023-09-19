using TMPro;
using UnityEngine;

namespace Scripts.UI 
{
    public class ScoreKill : MonoBehaviour, IService
    {
        [SerializeField] private TMP_Text _killText;
        public  int killCount { get; private set;}

       public void Kill()
       {
            killCount++;
            _killText.text = killCount.ToString();
       }
    } 
}

