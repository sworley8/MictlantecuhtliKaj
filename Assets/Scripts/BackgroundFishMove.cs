using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFishMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity = 4;
    void Movement()
    {
        transform.Translate(-transform.forward * Time.deltaTime * velocity, Space.World);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void OnDrawGizmos()
    {
        Vector3 forward = transform.forward * 10;
        Debug.DrawRay(transform.position, forward, Color.yellow);
    }
}
