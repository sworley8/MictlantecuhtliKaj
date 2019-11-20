using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutsceneStaticChange : MonoBehaviour
{
    public int SceneNumber;
    public DialogueEngine di;
    float timer;
    Boolean timerReached;
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene(SceneNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (!di.dialogueIsActive)
        {
            if (!timerReached)
                timer += Time.deltaTime;

            if (!timerReached && timer > 1)
            {
                Debug.Log("Done waiting");
                SceneManager.LoadScene(SceneNumber);

                //Set to false so that We don't run this again
                timerReached = true;
            }
        }

    }

}
