using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image HealthCircle;
    public int maxhealth = 100;
    public GameObject player;
    private int curr;
    MeshRenderer m;
    Material mat;
    public AudioSource ouch;
    public AudioSource exclaim;

    // Start is called before the first frame update
    void Start()
    {
        curr = maxhealth;
        m = player.GetComponent<MeshRenderer>();
        mat = m.material;
    }

    public void handleHealth(int damage)
    {
        curr -= damage;

        HealthCircle.fillAmount = (float)curr / (float)maxhealth;
  
    }
    IEnumerator coRoutineHealth(float waiting)
    {
        for (int i = 0; i < 2; i++)
        {
            mat.color = Color.red;
            Debug.Log(m.enabled);
            Debug.Log(player.name);
            yield return new WaitForSecondsRealtime(waiting);
            mat.color = Color.white;
            yield return new WaitForSecondsRealtime(waiting);

        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Main Camera" && collision.gameObject.tag != "BoxesM" && collision.gameObject.tag != "EnemyActivation")
        {
            if (curr > 0)
            {
                Debug.Log("============" + collision.gameObject.name + "==============");
                StartCoroutine(coRoutineHealth(0.25f));
                if (exclaim.isPlaying)
                {
                    exclaim.Pause();
                }
                ouch.Play();
                handleHealth(10);

            }
        }
    }
    void Update()
    {

    }

    public int GetHealth()
    {
        return curr;
    }

}
