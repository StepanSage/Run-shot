using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Logica.Weapon
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidbody;

        private void Start()
        {
            if(_rigidbody == null)
            {
                _rigidbody.GetComponent<Rigidbody>();
            }
        }
       

        private void FixedUpdate()
        {
            _rigidbody.velocity = transform.forward * _speed;
            RespawnBullet();
        }

        public void RespawnBullet()
        {
            if(transform.position.z >= 100)
            {
                gameObject.SetActive(false);
            }
        }
        


    }

}   

