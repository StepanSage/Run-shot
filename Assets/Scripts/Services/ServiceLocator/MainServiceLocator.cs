using Scripts.Logica.Weapon;
using UnityEngine;
using Scripts.Services.ServiceLocator;

namespace Scripts.Services.ServiceLocator 
{
    public class MainServiceLocator : MonoBehaviour
    {
        [SerializeField] private AbstractWepon _gun;
        public  void Initialization()
        {
            ServiceLocator.Initialization();
            _gun = FindObjectOfType<AbstractWepon>();
            ServiceLocator.Current.Registration<AbstractWepon>(_gun);

            
        }
    } 
}

