using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineActivatorRevised : MonoBehaviour
{
    public List<PlayableDirector> listOfCutscenes;
    public int activationCount;
    int ctr = 0;
    private bool isNextSceneReady = false;
    public AudioSource voiceAS;


    private void Update()
    {
        if (isNextSceneReady)
        {
            if (ctr < listOfCutscenes.Count && !voiceAS.isPlaying)
            {
                activateTimeline(listOfCutscenes[ctr]);
                ctr++;
            }
            isNextSceneReady = false;
        }
    }

    public void activateNextCutscene()
    {
        isNextSceneReady = true;
    }


    private void activateTimeline(PlayableDirector timeline)
    {
        timeline.Play();
    }
}
