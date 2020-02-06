using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeUntilFire;
    public MissileMovement missile1;
    public MissileMovement missile2;

    void Start()
    {
    }

    public void BeginMissileCountdown ()
    {
        StartCoroutine(Countdown(timeUntilFire));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Countdown(float time)
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / time;
            yield return null;
        }
        FireMissile();

    }

    private void FireMissile()
    {
        missile1.FireMissile();
        missile2.FireMissile();
    }

}
