using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float destroyTime = 3f;

    void Update()
    {
        transform.position += transform.forward * 0.1f;

        destroyTime -= Time.deltaTime;

        //Mermiler belli bir s�re sonunda yok olmal�
        if (destroyTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
