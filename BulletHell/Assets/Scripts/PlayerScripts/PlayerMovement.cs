using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float baseSpeed;
    float rageSpeed;
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
    }

    private void Update()
    {
        inRage = GetComponent<Player>().GetRage();

        dir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;


        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0 && CanMove())
        {
            speed *= 10f;
            dashCooldown = 0.5f;
            playerState = PlayerState.Dash;
        }


        if (playerState == PlayerState.Dash)
        {
            bullets = GameObject.FindGameObjectsWithTag("Bullet");

            for (int i = 0; i < bullets.Length; i++)
            {
                Physics2D.IgnoreCollision(coll, bullets[i].GetComponent<BoxCollider2D>());
            }

            transform.position += dir * speed * Time.deltaTime;
            speed -= speed * 10f * Time.deltaTime;

            if (speed < baseSpeed)
            {
                playerState = PlayerState.Normal;
                speed = baseSpeed;
            }
        }

        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        if (playerState == PlayerState.Normal)
            transform.position += dir * speed * Time.deltaTime;
    }

    //Check if there is a wall in front of player
    //Distance may need to be adjusted based on player/collider size
    bool CanMove()
    {
        return Physics2D.Raycast(transform.position, dir, distFromWall, wallLayer).collider == null;
    }

}
