using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraControl : MonoSingleton<SimpleCameraControl>
{
    private static Vector3 playerCameraDistance;

    private Transform player;

    private void Start()
    {
        player = Player.Singleton.transform;
        //Kamera oyun başındaki mesafeyi korumalı..
        playerCameraDistance = player.position - transform.position;
    }

    void Update()
    {
        transform.position = player.position - playerCameraDistance;
    }
}
