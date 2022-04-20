using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        // Returns a copy of vector with its magnitude clamped to maxLength
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}
