using Scripts.Services.PoolObject;
using Scripts.Services.Factory;
using UnityEngine;
using System.Collections.Generic;
using Scripts.UI;

namespace Scripts.Services.Factory.RealizationFactory
{
    public class RealizationFactory : MonoBehaviour
    {
        [SerializeField] private Transform[] _variantSpawn;
        [SerializeField] private float _delayBetweenSpawn;

        private Factory AreaOneFactory;
        private float _currentDelayBeetweenSpawn;
        private ScoreKill _scoreKill;

        private PoolObject<MeleeEnemy> _poolObject;
        private PoolObject<GoblinTank> _poolGoblinTank; 
     
    
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
            _scoreKill = ServiceLocator.ServiceLocator.Current.Get<ScoreKill>();
            AreaOneFactory = new AreanOneEnemyFactory();
            FillingEnemy();
        }
        public void FillingEnemy()
        {
           

            var prefabsMeleeEnemy = AreaOneFactory.MeleeEnemy();
            _poolObject = new PoolObject<MeleeEnemy>(prefabsMeleeEnemy, 6);

            var  pefabsGoblinTank = AreaOneFactory.GoblinTank();
            _poolGoblinTank = new PoolObject<GoblinTank>(pefabsGoblinTank, 7);
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
                    PercentSpawn();
                }
                else
                {
                    _delayBetweenSpawn -= Time.deltaTime;
                }
            
        }


        public void PercentSpawn()
        {
            int temp = Random.Range(0, 100);
            var numberPointSpawn = VariantSpawn();

           
           

            if (_scoreKill.killCount <= 4)
            {
                var enemymele = _poolObject.Get();
                if (enemymele.percentspawn <= temp)
                {
                   
                    enemymele.gameObject.transform.position = _variantSpawn[numberPointSpawn].position;
                }
            }
            else if (_scoreKill.killCount > 4 && _scoreKill.killCount <= 6)
            {
                var enemyGobkenTank = _poolGoblinTank.Get();
                enemyGobkenTank.gameObject.transform.position = _variantSpawn[numberPointSpawn].position;
            }
        }

        
    }
}

