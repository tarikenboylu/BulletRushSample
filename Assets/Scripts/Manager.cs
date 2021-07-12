using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoSingleton<Manager>
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0);//zaten tek sahne var sürekli ayný sahneyi load edecek
    }
}
