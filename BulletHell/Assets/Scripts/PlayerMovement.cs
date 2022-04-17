using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float baseSpeed;
    float dashSpeed;
    float dashCooldown;
    bool canRoll;

    enum PlayerState
    {
        Walk,
        Dash
    };

    private PlayerState playerState;

    [SerializeField] private Camera mainCamera;
    private Vector3 mousePos;
    private SpriteRenderer playerSprite;
    private Rigidbody2D player;


    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        player = GetComponent<Rigidbody2D>();
        baseSpeed = speed;
        dashSpeed = speed * 5;
        playerState = PlayerState.Walk;
    }

    private void Update()
    {

        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerState = PlayerState.Dash;
        }
        else
        {
            playerState = PlayerState.Walk;
        }

        //Scuffed dash code
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0)
        {
            speed *= 5;
            dashCooldown = 0.5f;
        }

        if(dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }
    if(speed > baseSpeed)
        {
            speed -= 100 * Time.deltaTime;
        }
        else
        {
            speed = baseSpeed;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        //GetAxisRaw disables ease in



        mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        //Find where the mouse is relative to player position then rotate player
        Vector3 difference = mousePos - gameObject.transform.position;
        

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
