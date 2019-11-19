using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1To2Change : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Do something else here11");
        //if (collision.gameObject.tag == "EnemyActivation" && enemyBezierCurve != null)
        //{
        //    Debug.Log("ACTIVATED: " + gameObject.name);
        //    enemyBezierCurve.Resume();

        //}
        if (collision.gameObject.tag == "Player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //Debug.Log("Do something else here");
            SceneManager.LoadScene(1);
        }
        //if (collision.gameObject.layer == 8)
        //{
        //    //Debug.Log("hit by lazer");
        //    //Debug.Log("killed by fire");
        //}
        //if (collision.gameObject.tag == "BoxesM")
        //{
        //    //If the GameObject has the same tag as specified, output this message in the console
        //    //Debug.Log("Do something else here66");
        //    checkMi = true;
        //    Debug.Log("Exclamation");
        //}
    }
}
