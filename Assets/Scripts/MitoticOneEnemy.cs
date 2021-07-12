using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MitoticOneEnemy : EnemyAI
{
    [SerializeField] private GameObject mitoticParts;

    void Update()
    {
        base.Update();

        //Eðer caný yarýnýn altýna düþerse bölünmesi..
        if (currentHP < 6)
        {
            for (int i = 0; i < 8; i++)
            {
                Vector3 randomPosition = Vector3.forward * Random.Range(-3, 3) + Vector3.right * Random.Range(-3, 3);
                Instantiate(mitoticParts, transform.position + randomPosition, Quaternion.identity);
            }

            Player.Singleton.GainScore();
            Destroy(gameObject);
        }
    }
}
