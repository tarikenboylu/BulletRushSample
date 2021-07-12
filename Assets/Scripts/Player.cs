using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoSingleton<Player>
{
    private Transform[] gunRotations = new Transform[2];
    [SerializeField] private Transform bullet;
    [SerializeField] private GameObject scoreText;

    private Transform target;
    private Transform target2;

    public int killCount = 0;

    [SerializeField]private VariableJoystick joystick;

    private float closestDistance;
    private float bulletCoolDown = 0.15f;

    private void Start()
    {
        gunRotations[0] = transform.GetChild(0);
        gunRotations[1] = transform.GetChild(1);

        InvokeRepeating("UpdateTarget", 0, 0.1f);
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal) * 0.2f;//basit şekilde hareket et fonksiyonu

        bulletCoolDown -= Time.deltaTime;
        #region Silahların hedefe yönlendirilmesi ve kurşun üretimi
        if (target != null)
        {
            gunRotations[0].LookAt(target, Vector3.up);
            gunRotations[1].LookAt(target2 != null ? target2 : target, Vector3.up);

            if (bulletCoolDown < 0)
            {
                Instantiate(bullet, gunRotations[0].GetChild(1).position, gunRotations[0].rotation);
                Instantiate(bullet, gunRotations[1].GetChild(1).position, gunRotations[1].rotation);
                bulletCoolDown = 0.15f;
            }
        }
        #endregion
        
        if (transform.position.y < 0)
        {
            print("GameOver \n Your Score :" + killCount);
            killCount = 0;
            Manager.Singleton.RestartGame();
        }
    }

    public void GainScore()
    {
        killCount++;
        scoreText.GetComponent<Text>().text = killCount + "";
    }

    //En yakın Düşmanı bulmak için uzaklığı kıyaslıyoruz
    //Eğer atış menzili içerisinde birden fazla düşman varsa ve
    //farklı taraflardaysa 2 tarafa nişan almasını sağlamalıyız
    #region Hedef Tayini
    private void UpdateTarget()
    {
        target = null;
        target2 = null;
        closestDistance = 20;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);

            if (distance < 20)
            {
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    target = enemy.transform;
                }
                else
                {
                    if (Vector3.Distance(enemy.transform.position, target.position) > 8)
                    {
                        target2 = enemy.transform;
                    }
                    else
                        target2 = null;
                }
            }
        }
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            print("GameOver \n Your Score :" + killCount);
            killCount = 0;
            Manager.Singleton.RestartGame();
        }
    }
}
