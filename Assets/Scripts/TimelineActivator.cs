using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineActivator : MonoBehaviour
{
    public List<PlayableDirector> timeline;//scalability for the possible future
    public DialogueEngine dialogueEngine;
    public int activationCount;
    int ctr = 0;//because time is short
    private void Update()
    { 
        int i = 0;
        if(Input.GetButtonDown("Fire1"))
        {
            ctr++;
        }
        if(ctr>= activationCount)
        {
            activateTimeline(timeline[i]);//this is where the scalability breaks down
        }
        else if (dialogueEngine.isEnded)
        {
            activateTimeline(timeline[i+1]);//need a better way of doing this
        }
    }

    private void activateTimeline(PlayableDirector timeline)
    {
        timeline.Play();
    }
}
