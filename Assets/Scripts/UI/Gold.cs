using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class Gold : MonoBehaviour, IService
    {
        [SerializeField] private TMP_Text _gold;

        private int _goldCouunt;

        public  void AddGold(int MinGold, int MaxGold)
        {
            int temp = Random.Range(MinGold, MaxGold);
            _goldCouunt += temp;
            _gold.text = _goldCouunt.ToString();
        }

    }
}
