using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway : MonoBehaviour {
    Vector3 startPosition;
    Vector3 startRotation;
    public float speed = 1;
    public float translate = 1;
    public float translateOffset = 0;
    
    public float yaw = 1;
    public float yawOffset = 0;
    // Start is called before the first frame update
    void Start() {
        startPosition = transform.localPosition;
        startRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update() {
        transform.localPosition = startPosition + new Vector3(translate * Mathf.Sin(Time.timeSinceLevelLoad * 3 * speed + translateOffset), 0, 0);
        transform.localEulerAngles = startRotation + new Vector3(0, yaw * Mathf.Sin(Time.timeSinceLevelLoad * 3 * speed + yawOffset), 0);
    }
}
