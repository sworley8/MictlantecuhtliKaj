using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneChange : MonoBehaviour
{
    public int SceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(SceneNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
