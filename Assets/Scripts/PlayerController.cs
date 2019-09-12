using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform gunNozzle1;
    public Transform gunNozzle2;
    public GameObject m_shotPrefab;
    Plane planeInFrontOfPlayer;
    public Canvas UICanvas;
    public Image targetImage;
    public float boundWidth;
    public float boundHeight;
    public float speed;
    public float followSpeed = .1f;
    public float minimumDistance = 5f;
    private Vector2Int cursorLocation = new Vector2Int(0, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject laser1 = GameObject.Instantiate(m_shotPrefab, gunNozzle1.position, gunNozzle1.rotation) as GameObject;
            GameObject laser2 = GameObject.Instantiate(m_shotPrefab, gunNozzle2.position, gunNozzle2.rotation) as GameObject;
            GameObject.Destroy(laser1, 3f);
            GameObject.Destroy(laser2, 3f);
            int layerMask = 1 << 9;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.BoxCast(transform.position, new Vector3(.5f, .5f, .5f), transform.forward, out hit, transform.rotation, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                hit.transform.gameObject.SetActive(false);
            }
        }
        Vector2Int screenNegClamp = new Vector2Int(0 - Screen.width / 2, 0 - Screen.height / 2);
        Vector2Int screenPosClamp = new Vector2Int(Screen.width / 2, Screen.height / 2);
        Vector2Int screenOffset = new Vector2Int(Screen.width / 2, Screen.height / 2);

        Mathf.Clamp(boundWidth, 0, Screen.width);
        Mathf.Clamp(boundHeight, 0, Screen.height);


        planeInFrontOfPlayer = new Plane(Camera.main.transform.forward, 0f);
        float distanceToOriginPlane = planeInFrontOfPlayer.GetDistanceToPoint(transform.position);
        planeInFrontOfPlayer.distance = -Mathf.Abs(distanceToOriginPlane);


        //Debug.Log(distanceToOriginPlane);

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(inputX, inputY);
        Vector2 deltaMovement = direction * Time.deltaTime * speed;
        Vector2Int deltaMovementInt = new Vector2Int((int)deltaMovement.x, (int)deltaMovement.y);

        cursorLocation += deltaMovementInt;
        cursorLocation.Clamp(screenNegClamp, screenPosClamp);

        
        Vector3 cursor2Screen = new Vector3(cursorLocation.x + screenOffset.x, cursorLocation.y + screenOffset.y, 0);



        // Get the mouse position in screen pixel coordinates
        //Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        MoveTowardsCursor(UICanvas, cursor2Screen);
        Ray cameraRay = Camera.main.ScreenPointToRay(cursor2Screen);

        //Debug.Log(Input.mousePosition.ToString("F4"));

        Debug.DrawRay(planeInFrontOfPlayer.normal * planeInFrontOfPlayer.distance, Vector3.up, Color.red);
        Debug.DrawRay(planeInFrontOfPlayer.normal * planeInFrontOfPlayer.distance, Vector3.right, Color.red);
        Debug.DrawRay(planeInFrontOfPlayer.normal * planeInFrontOfPlayer.distance, planeInFrontOfPlayer.normal, Color.red);


        float enter = 0f;
        if (planeInFrontOfPlayer.Raycast(cameraRay, out enter))
        {
            Vector3 intersection = cameraRay.GetPoint(enter);
            //Debug.Log(intersection.ToString("F5"));
            Debug.DrawRay(intersection, Vector3.up, Color.blue);
            if (Vector3.Distance(transform.position, intersection) > minimumDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, intersection, followSpeed);
            }
            transform.forward = cameraRay.direction;
        }





        Debug.DrawRay(cameraRay.origin, cameraRay.direction, Color.red);

    }

    public void PlayerControllerMovement()
    {

    }

    public void MoveTowardsCursor(Canvas canvas, Vector3 screenPos)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPos, canvas.worldCamera, out pos);
        targetImage.transform.position = canvas.transform.TransformPoint(pos);
        //targetImage.transform.position = Input.mousePosition;
    }
    void OnDrawGizmos()
    {
        

    }
}
