using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public float velocity = 5f;
    private bool isFire = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFire)
            transform.Translate(velocity * transform.forward * Time.deltaTime, Space.World);
    }

    public void FireMissile()
    {
        StartCoroutine(TimeSample());
    }

    private IEnumerator TimeSample()
    {
        Vector3 x0 = transform.position;
        float timeToWait = .1f;
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / timeToWait;
            yield return null;
        }
        //Debug.Log("hit!!!");
        Vector3 x1 = transform.position;
        float deltaDistance = Vector3.Distance(x0, x1);
        velocity += deltaDistance / timeToWait;
        Debug.Log(velocity);
        transform.parent = null;
        isFire = true;  

    }

}
