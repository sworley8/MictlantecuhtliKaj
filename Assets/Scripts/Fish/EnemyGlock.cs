using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlock : Glock
{

    // Update is called once per frame
    void Update()
    {
        top.localPosition = Vector3.Lerp(top.localPosition, startOffset, Time.deltaTime * 10);
        angle = Mathf.Lerp(angle, startAngle, Time.deltaTime * 10);
        transform.localEulerAngles = new Vector3(angle, 0, 0);


        
    }
}
