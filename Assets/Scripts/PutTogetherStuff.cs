using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTogetherStuff : MonoBehaviour
{
	//// Start is called before the first frame update
	void Start()
	{
		Jun_BezierCurve curve = gameObject.GetComponentInChildren(typeof(Jun_BezierCurve)) as Jun_BezierCurve;
		if (curve != null)
		{
			while (m_bezierPoints != null)
			{
				m_bezierPoints.transform.localPosition = m_bezierPoints.transform.localPosition - gameObject.transform.localPosition;

			}
		}
	}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //subtract empty object from each point in the array
    //while (m_bezierPoints != null) {
    //    m_bezierPoints.transform.localPosition = m_bezierPoints.transform.localPosition - gameObject.transform.localPosition
    //}
}
