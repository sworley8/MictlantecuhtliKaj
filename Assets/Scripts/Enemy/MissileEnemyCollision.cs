using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEnemyCollision : EnemyCollision
{
    public MissileEnemy missileScript;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementActivated)
        {
            Debug.Log(" owwwwwwwwwwwwwwwwwwwwwwwwwwwwww wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
            missileScript.BeginMissileCountdown();
            movementActivated = false;
        }  
    }


    public void Init()
    {
        base.Init();
        missileScript = GetComponent<MissileEnemy>();
    }
}
