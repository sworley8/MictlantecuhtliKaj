using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChoice : MonoBehaviour
{
    public int SceneNumber1;
    public int SceneNumber2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //B
            SceneManager.LoadScene(SceneNumber2);
            Debug.Log("Hello");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            //A
            SceneManager.LoadScene(SceneNumber1);
            Debug.Log("Hell");
        }
    }
}
