using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyApproch : MonoBehaviour
{
	public Image Exclaimation;
	public int flashingCount = 3;
    bool flagMi = false;
    private AudioSource exclaimSE;
    GameObject enemy;
    GameObject player;
    // Start is called before the first frame update
    void Start()
	{
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		player = GameObject.FindGameObjectWithTag("Player");
        Exclaimation.enabled = false;
        exclaimSE = GetComponent<AudioSource>();
        exclaimSE.Stop();
    }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(coRoutineExclaim(0.5f));
		}

        //if (EnemyCollision.checkIn == true && flagIn)
        //{
        //    flagOut = true;
        //    flagMi = true;
        //    flagIn = true;
        //    StartCoroutine(coRoutineExclaim(0.1f));
        //}
        if (EnemyCollision.checkMi == true && flagMi == false)
        {
            flagMi = true;
            StartCoroutine(coRoutineExclaim(0.5f));
            EnemyCollision.checkMi = false;
            flagMi = false;
            exclaimSE.Play();
        }
        //if (EnemyCollision.checkOut == true && flagOut == false)
        //{
        //    flagOut = true;
        //    StartCoroutine(coRoutineExclaim(0.8f));
        //}


        IEnumerator coRoutineExclaim(float waiting)
		{
		    for (int i = 0; i < flashingCount; i++)
		    {
                Exclaimation.enabled = true;
				yield return new WaitForSecondsRealtime(waiting);
                Exclaimation.enabled = false;
                yield return new WaitForSecondsRealtime(waiting);

            }


        }
	}
}
