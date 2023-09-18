using Scripts.Services.PoolObject;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Logica.Weapon 
{
    public abstract class AbstractWepon : MonoBehaviour, IService
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private int CountAmmo;
        [SerializeField] private float _currentDelayBeetWeenShots;

        private float _delayBeetweenShots;
        private PoolObject<Ammo> _poolObject;
        private Ammo _prefabsAmmo;

        public int damag { get; private set; }

        private void Start()
        {

            Initialized();
        }

        public void Initialized()
        {
            var _prefabs = Resources.Load("AmmoPrefabs/Ammo");
            _prefabsAmmo = _prefabs.GetComponent<Ammo>();
            _poolObject = new PoolObject<Ammo>(_prefabsAmmo, CountAmmo);
            damag = 1;
            _delayBeetweenShots = _currentDelayBeetWeenShots;
        }


        private void Update()
        {

            Shot();


        }

        protected  void Rechaege()
        {
            
        }

        protected  void Shot()
        {
            if(_currentDelayBeetWeenShots <= 0)
            {
                _currentDelayBeetWeenShots = _delayBeetweenShots;
                var Ammo = _poolObject.Get();
                Ammo.transform.position = _shootPoint.position;
            }
            else
            {
                _currentDelayBeetWeenShots -= Time.deltaTime;
                
            }

            
        }

    }
}

