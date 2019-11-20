using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivation : MonoBehaviour
{
    public DialogueEngine engine;
    // Start is called before the first frame update
    void Start()
    {
        engine.dialogueTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
