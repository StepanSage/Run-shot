using Scripts.Logica.Weapon;
using UnityEngine;
using Scripts.Services.ServiceLocator;
using Scripts.UI;

namespace Scripts.Services.ServiceLocator 
{
    public class MainServiceLocator : MonoBehaviour
    {
        [SerializeField] private AbstractWepon _gun;
        [SerializeField] private ScoreKill scoreKill;
        [SerializeField] private Gold _gold;
        public  void Initialization()
        {
            ServiceLocator.Initialization();
            _gun = FindObjectOfType<AbstractWepon>();
            ServiceLocator.Current.Registration<AbstractWepon>(_gun);
            ServiceLocator.Current.Registration<ScoreKill>(scoreKill);
            ServiceLocator.Current.Registration<Gold>(_gold); 

            
        }
    } 
}

