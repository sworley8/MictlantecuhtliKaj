using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineActivator : MonoBehaviour
{
    public List<PlayableDirector> playableDirector;//scalability for the possible future NOTE- this script currently only supports two timelines
    public DialogueEngine dialogueEngine;
    public int activationCount;
    public int ctr = 0;//because time is short
    //public AudioSource voiceAS;
    public DialogueEngine dialogue;
    private void Update()
    {
        TimelineControl();
    }

    private void TimelineControl()
    {
        int i = 0;
        //&& !voiceAS.isPlaying
        if (Input.GetButtonDown("Fire1") && dialogue.dialogueIsActive)
        {
            ctr++;
        }
        if (ctr >= activationCount)
        {
            activateTimeline(playableDirector[i]);//this is where the scalability breaks down 
        }
        if (dialogueEngine.isEnded)
        {
            deactivateTimeline(playableDirector[i]);
            activateTimeline(playableDirector[i + 1]);//need a better way of doing this
        }
    }

    private void deactivateTimeline(PlayableDirector PD)
    {
        PD.Pause();
    }

    private void activateTimeline(PlayableDirector PD)
    {
        PD.Play();
    }
}
