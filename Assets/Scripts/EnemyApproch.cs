using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyApproch : MonoBehaviour
{
	GameObject enemy;
	GameObject player;
	public Image Exclaimation;
	public int flashingCount = 3;
    bool flagOut = false;
    bool flagMi = false;
    bool flagIn = false;
    // Start is called before the first frame update
    void Start()
	{
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		player = GameObject.FindGameObjectWithTag("Player");
        Exclaimation.enabled = false;
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
                Debug.Log("Do something else h");
				yield return new WaitForSecondsRealtime(waiting);
                Exclaimation.enabled = false;
                yield return new WaitForSecondsRealtime(waiting);

            }


        }
	}
}
