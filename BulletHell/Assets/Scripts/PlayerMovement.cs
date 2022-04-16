using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 dashSpeed;

    [SerializeField] private Camera mainCamera;
    private Vector3 mousePos;
    private SpriteRenderer playerSprite;
    private Rigidbody2D player;


    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        player = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        //Dash code, not working yet
        if (Input.GetKey(KeyCode.LeftShift))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(player.velocity.x * 30, player.velocity.y * 30), ForceMode2D.Impulse);
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
