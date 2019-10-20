using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueEngine : MonoBehaviour
{
    // Start is called before the first frame update
    public List<DialogueObject> Script = new List<DialogueObject>();
    public Image CanvasImageLeft;
    public Image CanvasImageRight;
    public Image DialogueBox;
    public Text textBox;

    private int currentDialogue = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentDialogue < Script.Count)
        {
            CanvasImageLeft.enabled = true;
            CanvasImageRight.enabled = true;
            DialogueBox.enabled = true;
            textBox.enabled = true;
            textBox.text = Script[currentDialogue].dialogue;
            if (Script[currentDialogue].positionImage1 == DialogueObject.Position.Left)
            {
                CanvasImageLeft.sprite = Script[currentDialogue].image1;
                CanvasImageRight.sprite = Script[currentDialogue].image2;
                CanvasImageLeft.preserveAspect = true;
                CanvasImageRight.preserveAspect = true;
                Debug.Log(CanvasImageRight.sprite.name);

            }
            else
            {
                CanvasImageLeft.sprite = Script[currentDialogue].image2;
                CanvasImageRight.sprite = Script[currentDialogue].image1;
                CanvasImageLeft.preserveAspect = true;
                CanvasImageRight.preserveAspect = true;
            }
            if (Script[currentDialogue].speaker == DialogueObject.Position.Left)
            {
                Debug.Log("hit");
                CanvasImageRight.color = new Color32(186, 186, 186, 255);
                CanvasImageLeft.color = Color.white;
            } else
            {
                CanvasImageRight.color = Color.white;
                CanvasImageLeft.color = new Color32(186, 186, 186, 255);
            }
            currentDialogue++;
        }
        else if (Input.GetButtonDown("Fire1") && currentDialogue >= Script.Count)
        {
            CanvasImageLeft.enabled = false;
            CanvasImageRight.enabled = false;
            DialogueBox.enabled = false;
            textBox.enabled = false;
        }
        
    }
}
