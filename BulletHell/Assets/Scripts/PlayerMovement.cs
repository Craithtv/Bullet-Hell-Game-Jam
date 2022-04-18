using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float baseSpeed;
    float dashSpeed;
    float dashCooldown = 0;
    bool canRoll;
    [SerializeField] private LayerMask wallLayers;

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
        dashSpeed = speed * 10;
        playerState = PlayerState.Walk;
    }

    private void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = direction.normalized;

        switch (playerState)
        {
            case PlayerState.Walk:

                Movement();
                if(Input.GetKeyDown(KeyCode.LeftShift) && CanMove(direction, 1.5f))
                    Dash();
                break;

            case PlayerState.Dash:
                DashSlide(direction);
                break;
        }
    }

    private void FixedUpdate()
    {
        
    }

    void Movement()
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

    void Dash()
    {
        speed = dashSpeed;
        playerState = PlayerState.Dash;
    }

    void DashSlide(Vector3 slideDir)
    {
        transform.position += slideDir * speed * Time.deltaTime;
        player.GetComponent<BoxCollider2D>().enabled = false;

        speed -= speed * 10f * Time.deltaTime;
        if(speed < baseSpeed)
        {
            speed = baseSpeed;
            player.GetComponent<BoxCollider2D>().enabled = true;
            playerState = PlayerState.Walk;
        }
    }

    bool CanMove(Vector3 dir, float distance)
    {
        return Physics2D.Raycast(transform.position, dir, distance, wallLayers).collider == null;
    }

    bool TryMove(Vector3 baseMoveDir, float distance)
    {
        Vector3 moveDir = baseMoveDir;
        bool canMove = CanMove(moveDir, distance);
        if (!canMove)
        {
            moveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = moveDir.x != 0f && CanMove(moveDir, distance);
            if (!canMove)
            {
                moveDir = new Vector3(0f, baseMoveDir.y).normalized;
                canMove = moveDir.y != 0f && CanMove(moveDir, distance);
            }
        }

        if (canMove)
        {
            transform.position += moveDir * distance;
            return true;
        }
        else
        {
            return false;
        }

    }

    /*private void Update()
    {

        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.AddForce(new Vector2(speed, speed), ForceMode2D.Force);
            playerState = PlayerState.Dash;
            Debug.Log(playerState);
        }

        if (playerState == PlayerState.Dash)
        {
            speed = dashSpeed;
            dashCooldown = 0.5f;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            playerState = PlayerState.Walk;
        }


        //Scuffed dash code
        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }

        if (speed > baseSpeed)
        {
            speed -= 100 * Time.deltaTime;
        }

        else
        {
            playerState = PlayerState.Walk;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            speed = baseSpeed;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(playerState == PlayerState.Walk)
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

    bool canMove(Vector3 dir, float distance)
    {
        return Physics2D.Raycast(transform.position, dir, distance, wallLayers).collider == null;
    }*/

}
