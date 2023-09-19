using UnityEngine;

namespace Scripts.Logica
{ 
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbodyPlayer;
        [SerializeField] private float _speed;
        [SerializeField] private float _maxPosition;
        [SerializeField] private float _minPosition;
        [SerializeField] private Animator _animator;

        private float MoveX;
             
        void Start()
        {
            if(_rigidbodyPlayer == null)
                _rigidbodyPlayer= GetComponent<Rigidbody>();

            if (_animator == null)
               _animator = GetComponent<Animator>();

            
        }

       
        void Update()
        {
            MoveX= Input.GetAxis("Horizontal");
            AnimationMove(MoveX);
          
        }
        private void FixedUpdate()
        {
            _rigidbodyPlayer.velocity = new Vector3(MoveX * _speed, 0, 0);

            if (MoveX > 0 && transform.position.x >= _maxPosition)
            {
                _rigidbodyPlayer.velocity = Vector3.zero; 
                transform.position = new Vector3(_maxPosition, transform.position.y, transform.position.z);
                //MoveX = 0; 
            }
            else if (MoveX < 0 && transform.position.x <= -_minPosition)
            {
                _rigidbodyPlayer.velocity = Vector3.zero; 
                transform.position = new Vector3(-_minPosition, transform.position.y, transform.position.z);
                //MoveX = 0; 
            }
        }

        private void AnimationMove(float valum)
        {
            if (valum > 0 || valum < 0)
            {
                _animator.SetBool("Run", true);
            }
            else if(valum == 0)
            {
                _animator.SetBool("Run", false);
            }
            
           

        }
    }
}

