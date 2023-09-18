using Scripts.Logica;
using Scripts.Logica.Weapon;
using UnityEngine;


namespace Scripts.Services.Factory 
{
    public abstract class Unit : Characrteristics
    {
        [SerializeField] private PointAttackEnemy _pointAttackEnemy;
        
        
        protected AbstractWepon _gun;
        protected int MaxHealth;
        protected Vector3 _startPosition;


        private void Start()
        {
            MaxHealth = Health;
            _startPosition = transform.position;
            _gun = ServiceLocator.ServiceLocator.Current.Get<AbstractWepon>();
            _pointAttackEnemy = FindObjectOfType<PointAttackEnemy>();

        }

        private void Update()
        {
            Dead();
            Move();
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
            if(transform.position.z <= -4f)
            {
                Vector3 target = new Vector3(_pointAttackEnemy.transform.position.x, _pointAttackEnemy.transform.position.y, _pointAttackEnemy.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);

            }
            else
            {
                var direction = new Vector3(0, 0, -1f);
                transform.Translate(direction * Speed * Time.deltaTime);
            }



            //_rigidbody.AddForce(target * 30 * Time.deltaTime);
        }

        public void Dead()
        {
            if(Health <= 0)
            {
                Health = MaxHealth;
                gameObject.SetActive(false);
                transform.position = _startPosition;


            }
        }

        //public void OnTriggerEnter(Collider other)
        //{
        //    if(other != null)
        //    {
        //        if (other.gameObject.GetComponent<Ammo>())
        //        {
        //            TakeDamag();
        //            other.gameObject.SetActive(false);
        //        } 
        //    }
        //}

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

