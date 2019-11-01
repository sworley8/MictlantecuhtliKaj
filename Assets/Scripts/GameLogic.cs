using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject characterRig;
    public DialogueEngine dialogueEngine;
    public bool dialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.GetHealth() <= 0)
        {
            SceneManager.LoadScene("GameOverScreen");
        }

        if (Input.GetKeyDown("l"))
        {
            dialogueTrigger = true;
        }

        Dialogue();
    }

    void PauseScene()
    {
        characterRig.GetComponent<Jun_TweenRuntime>().enabled = false;
    }
    void ResumeScene()
    {
        characterRig.GetComponent<Jun_TweenRuntime>().enabled = true;
    }

    void Dialogue()
    {
        if (dialogueTrigger && !dialogueEngine.dialogueIsActive)
        {
            Debug.Log("aaaaaaaaaa");
            PauseScene();
            dialogueEngine.dialogueTrigger = true;
            dialogueTrigger = false;
        } else if (!dialogueEngine.dialogueIsActive)
        {
            
            ResumeScene();
        }
    }

}
