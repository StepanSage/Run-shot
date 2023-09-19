using Scripts.Services.Factory;
using System;
using System.Collections.Generic;
using UnityEngine;


public class AreanOneEnemyFactory : Factory
{
    public override GoblinTank GoblinTank()
    {
        var prefabs = Resources.Load<GameObject>("EnemyPrefabs/enemy2");
        var GoblinTank = prefabs.GetComponent<GoblinTank>();
        return GoblinTank;
    }

    public override MeleeEnemy MeleeEnemy()
    {
        var prefabs = Resources.Load<GameObject>("EnemyPrefabs/enemy");
        var  meleeEnemy= prefabs.GetComponent<MeleeEnemy>();
        return meleeEnemy;

    }

    
}
