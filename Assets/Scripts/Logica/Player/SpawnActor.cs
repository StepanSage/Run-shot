using Cinemachine;
using UnityEngine;

namespace Scripts.Logica.Player 
{
    public class SpawnActor : MonoBehaviour
    {
        private readonly Vector3 _pointSpawn = new Vector3(0, 0.5f, -12);

        private CinemachineVirtualCamera _CVC;

        public void Initializetion()
        {
            _CVC = FindObjectOfType<CinemachineVirtualCamera>();
        }

        void Start()
        {
           
            Spawn();
        }

        public void Spawn()
        {
            var PrefabsActor = Resources.Load<GameObject>("Actor/Actor");
            var Actor = Instantiate(PrefabsActor);
            _CVC.Follow = Actor.transform;
            Actor.transform.position = _pointSpawn;
        }
    }

}

