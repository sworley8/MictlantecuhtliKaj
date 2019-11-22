using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneChange : MonoBehaviour
{
    public int SceneNumber;
    public DialogueEngine di;
    public TimelineActivatorRevised timey;
    float timer;
    Boolean timerReached;
    public int transitionTime;
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene(SceneNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (!di.dialogueIsActive && timey.activationCount == timey.listOfCutscenes.Count)
        {
            if (!timerReached)
                timer += Time.deltaTime;

            if (!timerReached && timer > transitionTime)
            {
                Debug.Log("Done waiting");
                SceneManager.LoadScene(SceneNumber);

                //Set to false so that We don't run this again
                timerReached = true;
            }
        }

    }
}
