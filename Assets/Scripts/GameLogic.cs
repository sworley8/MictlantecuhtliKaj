using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject characterRig;
    public PlayerController playerController;
    public DialogueEngine dialogueEngine;
    public bool dialogueTrigger;
    public float pauseTimeStamp;

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
        playerController.DisableInput();
        if (characterRig != null)
        {
            characterRig.GetComponent<Jun_TweenRuntime>().Pause();
        }
    }

    void ResumeScene()
    {
        playerController.EnableInput();
        if (characterRig != null)
        {
            characterRig.GetComponent<Jun_TweenRuntime>().Resume();
        }
    }

    void Dialogue()
    {
        if (dialogueTrigger && !dialogueEngine.dialogueIsActive)
        {
            PauseScene();
            dialogueEngine.dialogueTrigger = true;
            dialogueTrigger = false;
        } else if (!dialogueEngine.dialogueIsActive)
        {
            
            ResumeScene();
        }
    }
    public void StartDialogue()
    {
        dialogueTrigger = true;
    }
}
