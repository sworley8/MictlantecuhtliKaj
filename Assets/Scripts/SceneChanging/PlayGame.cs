using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void playKaj()
    {
        //SceneManager.LoadScene(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void creditKaj()
    {
        SceneManager.LoadScene(1);
    }
    public void quitKaj()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}