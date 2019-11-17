using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        int layerMask = 1 << 13;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.BoxCast(transform.position, new Vector3(.5f, .5f, .5f), transform.forward, out hit, transform.rotation, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            float distanceBetween = Vector3.Distance(transform.position, laser3.transform.position) / 200;
            Debug.Log("I am : " + " and I hit: ");
            int damage = (int)(scaledDamage * distanceBetween + minDamage);
            if (hit.transform.tag == "Player")
            {
                ph.handleHealth(damage);
            }
        }
    }
    void OnDrawGizmos()
    {
        Vector3 forward = transform.forward * 10;
        Debug.DrawRay(transform.position, forward, Color.cyan);
    }
}
