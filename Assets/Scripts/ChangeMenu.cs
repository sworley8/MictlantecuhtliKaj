using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeMenu : MonoBehaviour
{
    public float timerBack = 120f;
    GameObject backgroundImage;
    GameObject backgroundImage2;
    public AudioSource song;
    // Start is called before the first frame update
    void Start()
    {
        backgroundImage = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("Back"));
        backgroundImage2 = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("Back2"));
    }

    // Update is called once per frame
    void Update()
    {
        timerBack -= Time.deltaTime;
        if (timerBack < 0)
        {
            if (backgroundImage.activeSelf == true)
            {
                backgroundImage.SetActive(false);
                song.Pause();
                timerBack = 120f + +Time.deltaTime;
            }
            if (backgroundImage2.activeSelf == true)
            {
                backgroundImage2.SetActive(false);
                song.Pause();
                timerBack = 120f + +Time.deltaTime;
            }
        }
    }
}
