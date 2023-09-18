using Scripts.Services.PoolObject;
using Scripts.Services.Factory;
using UnityEngine;
using System.Collections.Generic;

namespace Scripts.Services.Factory.RealizationFactory
{
    public class RealizationFactory : MonoBehaviour
    {
        [SerializeField] private Transform[] _variantSpawn;
        [SerializeField] private float _delayBetweenSpawn;

    
        private Factory AreaOneFactory;
        private PoolObject<Characrteristics> _poolObject;
        private PoolObject<GoblinTank> poolGoblinTank; 
        private float _currentDelayBeetweenSpawn;

     
    
        void Start()
        {
            Initialized(); 
        }
        private void Update()
        { 
            Spawn();   
        }

        public void Initialized()
        {
            _currentDelayBeetweenSpawn = _delayBetweenSpawn;
            FillingEnemy();
        }
        public void FillingEnemy()
        {
            AreaOneFactory = new AreanOneEnemyFactory();

            var prefabsMeleeEnemy = AreaOneFactory.MeleeEnemy();
            _poolObject = new PoolObject<Characrteristics>(prefabsMeleeEnemy, 6);

            var  pefabsGoblinTank = AreaOneFactory.GoblinTank();
            poolGoblinTank = new PoolObject<GoblinTank>(pefabsGoblinTank, 7);
        }

        public int VariantSpawn()
        {
            int variant = Random.Range(0, _variantSpawn.Length);
            return variant;
        }




        public void Spawn()
        {
            
                if(_delayBetweenSpawn <= 0)
                {
                    _delayBetweenSpawn = _currentDelayBeetweenSpawn;
                    var enemy = _poolObject.Get();
                    var numberPointSpawn = VariantSpawn();
                    enemy.gameObject.transform.position = _variantSpawn[numberPointSpawn].position;
                }
                else
                {
                    _delayBetweenSpawn -= Time.deltaTime;
                }
            
        }
    }
}

