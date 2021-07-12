using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedyOneEnemy : EnemyAI
{
    void FixedUpdate()
    {
        transform.LookAt(player, Vector3.up);
    }
}
