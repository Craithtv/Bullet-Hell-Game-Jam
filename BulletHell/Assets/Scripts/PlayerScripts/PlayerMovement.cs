using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float baseSpeed;
    float rageSpeed;
    float dashSpeed;
    float dashCooldown;

    BoxCollider2D coll;
    GameObject[] bullets;

    [SerializeField] private LayerMask wallLayer;
    public float distFromWall;

    Vector3 dir;

    Vector3 playerDir;

    enum PlayerState
    {
        Normal,
        Rage,
        Dash
    };

    bool inRage;

    private PlayerState playerState;

    [SerializeField] private Camera mainCamera;
    private Vector3 mousePos;
    private SpriteRenderer playerSprite;


    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        baseSpeed = speed;
        playerState = PlayerState.Normal;
        rageSpeed = speed * 2;
        dashSpeed = speed * 5;
    }

    private void Update()
    {
        inRage = GetComponent<Player>().GetRage();

        dir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        switch (playerState)
        {
            case (PlayerState.Normal):
                speed = baseSpeed;
                if (inRage == true)
                    playerState = PlayerState.Rage;
                if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0 && CanMove())
                {
                    dashCooldown = 0.5f;
                    playerState = PlayerState.Dash;
                }
                break;

            case (PlayerState.Dash):
                bullets = GameObject.FindGameObjectsWithTag("Bullet");

                for (int i = 0; i < bullets.Length; i++)
                {
                    Physics2D.IgnoreCollision(coll, bullets[i].GetComponent<BoxCollider2D>());
                }

                transform.position += dir * dashSpeed * Time.deltaTime;
                dashSpeed -= dashSpeed * 10f * Time.deltaTime;

                if (dashSpeed < baseSpeed)
                {
                    if (inRage == false)
                        playerState = PlayerState.Normal;
                    else if (inRage)
                        playerState = PlayerState.Rage;
                    dashSpeed = baseSpeed * 5;
                }
                break;

            case (PlayerState.Rage):
                speed = rageSpeed;
                if (!inRage)
                    playerState = PlayerState.Normal;
                if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0 && CanMove())
                {
                    dashCooldown = 0.3f;
                    playerState = PlayerState.Dash;
                }
                break;
        }

        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        if (playerState == PlayerState.Normal)
            Movement(speed);

        if (playerState == PlayerState.Rage)
            Movement(speed);
    }

    //Check if there is a wall in front of player
    //Distance may need to be adjusted based on player/collider size
    bool CanMove()
    {
        return Physics2D.Raycast(transform.position, dir, distFromWall, wallLayer).collider == null;
    }

    private void Movement(float stateSpeed)
    {
        transform.position += dir * stateSpeed * Time.deltaTime;
    }

}
