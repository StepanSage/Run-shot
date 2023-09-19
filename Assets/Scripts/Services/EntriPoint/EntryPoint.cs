using Scripts.Logica.Player;
using Scripts.Services.ServiceLocator;
using UnityEngine;

namespace Scripts.Services.EntryPoint 
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private MainServiceLocator _mainServiceLocator;
        [SerializeField] private SpawnActor _spawmActor;
        
        private void Awake()
        {

            EventBus.Initalization();
            _spawmActor.Initializetion();
            _mainServiceLocator.Initialization();
        }
    }
}

