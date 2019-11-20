using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    //public float timerBack = 20f;
    GameObject backgroundImage;
    public void playKaj()
    {
        SceneManager.LoadScene(13);

    }
    public void menuKaj()
    {
        SceneManager.LoadScene(0);

    }
    public void creditKaj()
    {
        SceneManager.LoadScene(2);
    }
    public void quitKaj()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}