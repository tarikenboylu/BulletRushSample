using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;

    private float spawnCooldown = 0.1f;

    void FixedUpdate()
    {
        if (spawnCooldown < 0)
        {
            #region Konum Atamasý - Düþman Seçimi random olarak yapýlýyor
            int x = Random.Range(0, 2), z = Random.Range(0, 2);
            int n = Random.Range(0, Enemies.Length);
            x = (x == 0) ? -10 : 10;
            z = (z == 0) ? -10 : 10;
            #endregion

            Instantiate(Enemies[n], new Vector3(x, Enemies[n].transform.position.y, z), Quaternion.identity);

            //Düþman zorluðuna göre bir sonraki spawn süresi deðiþiyor
            if (n == 0)
                spawnCooldown = 0.25f;
            else if (n == 1)
                spawnCooldown = 0.5f;
            else if (n == 2)
                spawnCooldown = 1.5f;
            else if (n == 3)
                spawnCooldown = 0.25f;
        }
        spawnCooldown -= Time.fixedDeltaTime;
    }
}
