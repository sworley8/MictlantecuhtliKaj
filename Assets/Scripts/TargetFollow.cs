using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetFollow : MonoBehaviour
{

    public Canvas targetCanvas;
    public Image targetImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsCursor();
    }

    public void MoveTowardsCursor()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(targetCanvas.transform as RectTransform, Input.mousePosition, targetCanvas.worldCamera, out pos);
        targetImage.transform.position = targetCanvas.transform.TransformPoint(pos);
        //targetImage.transform.position = Input.mousePosition;
    }
}
