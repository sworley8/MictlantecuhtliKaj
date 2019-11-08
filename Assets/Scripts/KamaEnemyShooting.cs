using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class KamaEnemyShooting : MonoBehaviour
{
    public float maxDamage = 50f;
    public float minDamage = 20f;
    public float reloadTime = 0.2f;
    public float enemyRange = 2f;
    public float targetStart = 2f;
    public float targetEnd = 0f;
    private Transform kamaEnemy;
    private PlayerHealth ph;
    public Transform gunNozzle3;
    public Transform gunNozzle4;
    public GameObject m_shotPrefab;
    Vector3 rayCastDir;
    private bool shots;
    //private LineRenderer shotLine;
    private float scaledDamage;
    // Start is called before the first frame update
    void Start()
    {
        //shotLine = GetComponentInChildren<LineRenderer>;
        kamaEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        scaledDamage = maxDamage - minDamage;

    }

    // Update is called once per frame
    void Update()
    {
        targetStart -= Time.deltaTime;
        if (targetStart <= targetEnd)
        {
            reloadTime -= Time.deltaTime;
            if (reloadTime <= 0f)
            {
                Shootings();
                reloadTime = 0.2f;
                targetStart = 2f;
            }
        }
        //if (!shots && (reloadTime != 0))
        //{
        //    Shootings();
        //}
        //if (reloadTime == 0)
        //{
        //    reloadTime = 3f;
        //}
    }
    void Shootings()
    {
        GameObject laser3 = GameObject.Instantiate(m_shotPrefab, gunNozzle3.position, gunNozzle3.rotation) as GameObject;
        GameObject laser4 = GameObject.Instantiate(m_shotPrefab, gunNozzle4.position, gunNozzle4.rotation) as GameObject;
        GameObject.Destroy(laser3, 3f);
        GameObject.Destroy(laser4, 3f);
        //shots = true;
        RaycastHit hitted;
        rayCastDir = kamaEnemy.transform.position;
        if (Physics.Raycast(gameObject.transform.position, rayCastDir, out hitted, enemyRange))
        {
            Debug.DrawLine(transform.position, hitted.point, Color.green);
            Debug.Log("I am : " + transform.name + " and I hit: " + hitted.transform.name);
        }
        float distanceBetween = Vector3.Distance(transform.position, kamaEnemy.position) / 200;
        int damage = (int)(scaledDamage * distanceBetween + minDamage);
        if (kamaEnemy.tag == "Player")
        {
            ph.handleHealth(damage);
        }
    }
    void OnDrawGizmos()
    {
        Vector3 forward = transform.forward * 10;
        Debug.DrawRay(transform.position, forward, Color.cyan);
    }
}
