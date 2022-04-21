using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 cameraOffset;
    public float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = player.position + cameraOffset;
        transform.position = player.position;
    }

    /*
    // Update is called once per frame
    void Update()
    {

        Debug.Log("Camera xPos: " + transform.position.x);
        Debug.Log("Camera yPos: " + transform.position.y);
        Debug.Log("Player xPos: " + player.transform.position.x);
        Debug.Log("Player yPos: " + player.transform.position.y);

        if (player.transform.position.x < transform.position.x - 2.5)
        {
            transform.position += new Vector3(-0.01f, 0);
        }
        if (player.transform.position.x > transform.position.x + 2.5)
        {
            transform.position -= new Vector3(-0.01f, 0);
        }
    }
    */


    //https://www.sebastianhutteri.com/blog/how-to-get-that-silky-smooth-camera-movement-in-unity

    private void FixedUpdate()
    {

        Vector3 finalPosition = player.position + cameraOffset;
        Vector3 lerpPosition = Vector3.Lerp(transform.position, finalPosition, cameraSpeed);
        transform.position = new Vector3(lerpPosition.x, lerpPosition.y, -10);

        
    }
}
