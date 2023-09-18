using Scripts.Services.Factory;
using UnityEngine;


public class AreanOneEnemyFactory : Factory
{
    
    public override MeleeEnemy MeleeEnemy()
    {
        var prefabs = Resources.Load<GameObject>("EnemyPrefabs/enemy");
        var  meleeEnemy= prefabs.GetComponent<MeleeEnemy>();
        return meleeEnemy;

    }
}
