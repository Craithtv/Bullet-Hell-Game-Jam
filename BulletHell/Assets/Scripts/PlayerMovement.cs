using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] private Camera mainCamera;
    private Vector3 mousePos;
    private SpriteRenderer playerSprite;

    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input. GetAxisRaw("Horizontal"), Input. GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        //GetAxisRaw disables ease in

        mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        //Find where the mouse is relative to player position then rotate player
        Vector3 difference = mousePos - gameObject.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);


        //Flips the sprite on Y-axis when mouse is on the left side of player
        if(difference.x < 0)
        {
            playerSprite.flipY = true;
        }
        else
        {
            playerSprite.flipY = false;
        }


        

    }
}
