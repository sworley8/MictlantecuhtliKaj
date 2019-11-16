using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeGlitch : MonoBehaviour
{
    public float timerBack = 3f;
    GameObject backgroundImage1;
    GameObject backgroundImage2;
    GameObject ember;
    GameObject bubbles;
    // Start is called before the first frame update
    void Start()
    {
        ember = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("Embers"));
        backgroundImage2 = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("Back2"));
        bubbles = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("Bubbles"));
        backgroundImage1 = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("Back"));

    }

    // Update is called once per frame
    void Update()
    {
        timerBack -= Time.deltaTime;
        if (timerBack < 0)
        {
            if (ember.activeSelf == true && backgroundImage2.activeSelf == false)
            {
                bubbles.SetActive(true);
                backgroundImage1.SetActive(true);
                ember.SetActive(false);
            }
            if (bubbles.activeSelf == true && backgroundImage1.activeSelf == false)
            {
                ember.SetActive(true);
                backgroundImage2.SetActive(true);
                bubbles.SetActive(false);
            }
            else
            {
                timerBack = 3f + Time.deltaTime;
            }
        }
    }
}
