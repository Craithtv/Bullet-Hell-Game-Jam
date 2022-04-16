using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] private LayerMask wallLayers;
    [SerializeField] private Camera mainCamera;
    private Vector3 mousePos;
    private SpriteRenderer playerSprite;



    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        //GetAxisRaw disables ease in
        

        mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        //Find where the mouse is relative to player position then rotate player
        Vector3 difference = mousePos - gameObject.transform.position;
        
        //This would rotate the player, but trying out rotate weapon instead of player so this code may not be needed
        //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        //Flips the sprite on X-axis when mouse is on the left side of player
        if (difference.x < 0)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }
    }
}
