using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image HealthCircle;
    public int maxhealth = 100;
    private int curr;
    // Start is called before the first frame update
    void Start()
    {
        curr = maxhealth;
    }

    private void handleHealth(int damage)
    {
        curr -= damage;
        HealthCircle.fillAmount = (float)curr / (float)maxhealth;
    }
    //void TakeDamage(float damage)
    //{
    //    curr = curr - damage;
    //    HealthCircle.fillAmount = curr;

    //}
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (curr > 0)
            {
                handleHealth(10);
                Debug.Log("Do something else here");

            }
        }
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    handleHealth(10);
        //}
    }

    public int GetHealth()
    {
        return curr;
    }

}
