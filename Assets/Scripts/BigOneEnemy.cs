using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigOneEnemy : EnemyAI
{

    void Update()
    {
        transform.localScale = ((currentHP / 10) + 1) * Vector3.one;
        base.Update();
    }
}
