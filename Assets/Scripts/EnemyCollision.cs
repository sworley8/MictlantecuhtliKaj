using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public static bool checkIn = false;
    public static bool checkMi = false;
    public static bool checkOut = false;
    public Jun_TweenRuntime enemyBezierCurve;
    // Start is called before the first frame update
    void Start()
    {
        enemyBezierCurve = GetComponent<Jun_TweenRuntime>();
        if (enemyBezierCurve != null)
        {
            enemyBezierCurve.Pause();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Do something else here11");
        if (collision.gameObject.tag == "EnemyActivation" && enemyBezierCurve != null)
        {
            Debug.Log("ACTIVATED: " + gameObject.name);
            enemyBezierCurve.Resume();

        }
        if (collision.gameObject.tag == "Player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //Debug.Log("Do something else here");
            gameObject.SetActive(false);
        }
        if (collision.gameObject.layer == 8)
        {
            //Debug.Log("hit by lazer");
            //Debug.Log("killed by fire");
        }
        if (collision.gameObject.tag == "BoxesM")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //Debug.Log("Do something else here66");
            checkMi = true;
            Debug.Log("Exclamation");
        }
    }
}
