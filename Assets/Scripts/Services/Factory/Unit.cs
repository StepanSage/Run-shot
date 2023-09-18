using Scripts.Logica;
using Scripts.Logica.Weapon;
using UnityEngine;
using Scripts.UI;
using Scripts.Services.ServiceLocator;

namespace Scripts.Services.Factory 
{
    public abstract class Unit : Characrteristics
    {
        [SerializeField] private PointAttackEnemy _pointAttackEnemy;

        private ScoreKill _scoreKill;
        private Gold _gold;
          
        protected AbstractWepon _gun;
        protected int MaxHealth;
        protected Vector3 _startPosition;
        protected float SpeedCurrent;


        private void Start()
        {
            MaxHealth = Health;
            _startPosition = transform.position;
            _gun = ServiceLocator.ServiceLocator.Current.Get<AbstractWepon>();
            _pointAttackEnemy = FindObjectOfType<PointAttackEnemy>();
            _scoreKill = ServiceLocator.ServiceLocator.Current.Get<ScoreKill>();
            _gold = ServiceLocator.ServiceLocator.Current.Get<Gold>();

        }
       
        private void Update()
        {
            
            Move();
            Dead();
        }

        public  void DealingDamag()
        {
            int CurrentChanceCrete = Random.Range(0, 100); 
            int CurrentAccuracy = Random.Range(0, 100);

            if(CurrentAccuracy > CurrentChanceCrete)
            {
                if(CurrentChanceCrete < ChanceCrete)
                {

                }
            }
        }

        public void TakeDamag()
        {
            Health -= _gun.damag; 
        }
        public void Move()
        {
            if (transform.position.z <= -4f)
            {
                Vector3 target = new Vector3(_pointAttackEnemy.transform.position.x, _pointAttackEnemy.transform.position.y, _pointAttackEnemy.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
            }
            else
            {
                var direction = new Vector3(0, 0, -1f);
                transform.Translate(direction * Speed * Time.deltaTime);


            }
        }

        public void Dead()
        {
            if(Health <= 0)
            {
                Health = MaxHealth;
                _scoreKill.Kill();
                _gold.AddGold(MinGold, MaxGold);
                transform.position = _startPosition;
                gameObject.SetActive(false);
               
                
            }
        }
        public void OnCollisionEnter(Collision collision)
        {
            if (collision != null)
            {
                if (collision.gameObject.GetComponent<Ammo>())
                {
                    TakeDamag();
                    collision.gameObject.SetActive(false);
                    
                }
            }
        }

        

    }
}

