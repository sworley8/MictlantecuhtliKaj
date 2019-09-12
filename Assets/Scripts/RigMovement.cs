using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigMovement : MonoBehaviour
{

    public float velocity = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveRig();
    }

    public void MoveRig()
    {
        transform.Translate(transform.forward * Time.deltaTime * velocity);
    }
}
