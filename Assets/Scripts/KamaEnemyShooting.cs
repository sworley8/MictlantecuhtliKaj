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
    public Transform gunNozzle3;
    public Transform gunNozzle4;
    public GameObject m_shotPrefab;
    Vector3 rayCastDir;
    private bool shots;
    private bool isActivated;
    public bool stationaryRotate = false;
    public float minDistanceToStartShooting = 100f;
    private Transform player;
    //private LineRenderer shotLine;
    private float scaledDamage;
    private Vector3 prevPlayerPos;
    public float rotationSpeed;
    public Vector3 lazerOffset;
    public AudioSource shoot;
    public GameObject puff;
    Material[] mats;
    Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        //shotLine = GetComponentInChildren<LineRenderer>;
        //kamaEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        scaledDamage = maxDamage - minDamage;
        mats = puff.GetComponent<MeshRenderer>().materials;
        originalColor = mats[0].color;

    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            Vector3 estimatedNewPos;
            float bulletSpeed = m_shotPrefab.GetComponentInChildren<ShotBehavior>().speed;
            //Debug.Log(Vector3.Distance(transform.position, player.position) / bulletSpeed);
            estimatedNewPos = player.position + (Vector3.Distance(transform.position, player.position) / bulletSpeed * ((player.position - prevPlayerPos) / Time.deltaTime));
            estimatedNewPos += lazerOffset;
            float step = rotationSpeed * Time.deltaTime;
            Vector3 delta = Vector3.RotateTowards(transform.forward, estimatedNewPos - transform.position, step, 0f);
            //transform.rotation = Quaternion.LookRotation(estimatedNewPos - transform.position, Vector3.up);
            transform.rotation = Quaternion.LookRotation( delta, Vector3.up);
            //Debug.Log(player.position);
            targetStart -= Time.deltaTime;
            //mats[0].color = Color.red;
            if (targetStart >= 0.5f)
            {
                mats[0].color = originalColor;
            } else
            {
                mats[0].color = Color.magenta;
            }
            if (targetStart <= targetEnd)
            {
                
                reloadTime -= Time.deltaTime;
                if (reloadTime <= 0f)
                {
        
                    Shootings();
                    reloadTime = 0.25f;
                    targetStart = 2f;
                }

                    
                //if (reloadTime <= 0f)
                //{
                //    Shootings();
                //    reloadTime = 0.2f;
                //    targetStart = 2f;
                //}
     

            }
            prevPlayerPos = player.transform.position;
        }
    }
    void Shootings()
    {
        GameObject laser3 = GameObject.Instantiate(m_shotPrefab, gunNozzle3.position, gunNozzle3.rotation) as GameObject;
        GameObject laser4 = GameObject.Instantiate(m_shotPrefab, gunNozzle4.position, gunNozzle4.rotation) as GameObject;
        shoot.Play();
        GameObject.Destroy(laser3, 3f);
        GameObject.Destroy(laser4, 3f);
        //shots = true;
        int layerMask = 1 << 13;
    }
    void OnDrawGizmos()
    {
        Vector3 forward = transform.forward * 10;
        Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
    }

    void OnTriggerEnter(Collider collision)
    {
        float distanceToPlayer = Vector3.Distance(collision.transform.position, transform.position);
        Debug.Log(distanceToPlayer);
        if (collision.transform.tag == "EnemyActivation" && distanceToPlayer > minDistanceToStartShooting)
        {
            player = collision.transform;
            prevPlayerPos = player.position;
            isActivated = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "EnemyActivation")
        {
            isActivated = false;
        }
    }
}
