using UnityEngine;

namespace Scripts.Services.Factory 
{
    public class Characrteristics : MonoBehaviour
    {
        [SerializeField] protected int Damag;
        [SerializeField] protected int Health;
        [SerializeField] protected int ChanceCrete;
        [SerializeField] protected int Accuracy;
        public float Speed;
        public int MinGold;
        public int MaxGold;
        public float percentspawn;
    }
}

