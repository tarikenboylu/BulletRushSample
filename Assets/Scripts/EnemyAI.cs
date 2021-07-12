using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    protected Transform player;
    private float distancetoPlayer;
    private float moveSpeed = 2f;
    protected float currentHP;

    void Start()
    {
        currentHP = enemy.HP;
        moveSpeed = enemy.moveSpeed;

        player = Player.Singleton.transform;
    }

    protected void Update()
    {
        #region Basit Düşman AI oyuncuyu(Player) takip ediyor
        if (player != null)
        {
            distancetoPlayer = Vector3.Distance(player.position, transform.position);

            if (distancetoPlayer < 33 && distancetoPlayer > 0.1f)
            {
                GetComponent<Rigidbody>().velocity = (Vector3.Normalize(player.position - transform.position) * moveSpeed);
            }
        }
        #endregion

        //Canı Biteni Yok et
        if (currentHP < 0)
        {
            Player.Singleton.GainScore();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            currentHP -= 1;
        }
    }
}
