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
            #region Konum Atamas� - D��man Se�imi random olarak yap�l�yor
            int x = Random.Range(0, 2), z = Random.Range(0, 2);
            int n = Random.Range(0, Enemies.Length);
            x = (x == 0) ? -10 : 10;
            z = (z == 0) ? -10 : 10;
            #endregion

            Instantiate(Enemies[n], new Vector3(x, Enemies[n].transform.position.y, z), Quaternion.identity);

            //D��man zorlu�una g�re bir sonraki spawn s�resi de�i�iyor
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
