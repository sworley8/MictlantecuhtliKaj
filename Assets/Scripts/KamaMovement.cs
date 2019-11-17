using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamaMovement : MonoBehaviour
{
    public Quaternion originalRotationVal;
    public float velocity = 4;
    //move in local rotation with respect to world
    void Movement()
    {
        transform.Translate(-transform.forward * Time.deltaTime * velocity, Space.World);

    }
    // Start is called before the first frame update
    void Start()
    {
        originalRotationVal = transform.rotation;
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
