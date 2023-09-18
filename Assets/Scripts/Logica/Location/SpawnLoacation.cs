using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoacation : MonoBehaviour
{
    
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        var prafabs = Resources.Load<GameObject>("GlobalLocation/GlobalLocation Variant");
        var Location = Instantiate<GameObject>(prafabs);
        
    }
}
