using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    public SpriteRenderer sprites;
    public Sprite [] directionSprites;
    public Animator anim;
    private bool facingRight = false;
    private bool facingLeft = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    


        //attacks
        if (Input.GetMouseButton(0) && (GetComponent<Player>().GetRage() == false) && facingLeft == true)
        {
            anim.Play("leftpunchPC");
        }
        else if (Input.GetMouseButton(0) && (GetComponent<Player>().GetRage() == false) && facingRight == true)
        {
            anim.Play("rightpunchPC");
        }
        else if (Input.GetMouseButton(0) && (GetComponent<Player>().GetRage() == true) && facingLeft == true)
        {
            anim.Play("leftpunchRagePC");
        }
        else if (Input.GetMouseButton(0) && (GetComponent<Player>().GetRage() == true) && facingRight == true)
        {
            anim.Play("rightpunchRagePC");
        }
        else if (Input.GetMouseButton(1) && (GetComponent<Player>().GetRage() == false) && facingLeft == true)
        {
            anim.Play("leftpunchPC");
        }
        else if (Input.GetMouseButton(1) && (GetComponent<Player>().GetRage() == false) && facingRight == true)
        {
            anim.Play("rightpunchPC");
        }
        else if (Input.GetMouseButton(1) && (GetComponent<Player>().GetRage() == true) && facingLeft == true)
        {
            anim.Play("leftpunchRagePC");
        }
        else if (Input.GetMouseButton(1) && (GetComponent<Player>().GetRage() == true) && facingRight == true)
        {
            anim.Play("rightpunchRagePC");
        }


        else if (Input.GetKey(KeyCode.A) && GetComponent<Player>().GetRage() == false)
        {
            anim.Play("leftrunPC");
            facingLeft = true;
            facingRight = false;
        }
        else if (Input.GetKey(KeyCode.D) && GetComponent<Player>().GetRage() == false)
        {
            anim.Play("rightrunPC");
            facingLeft = false;
            facingRight = true;
        }
        else if (Input.GetKey(KeyCode.W) && GetComponent<Player>().GetRage() == false)
        {
            anim.Play("uprunPC");
        }
        else if (Input.GetKey(KeyCode.S) && GetComponent<Player>().GetRage() == false)
        {
            anim.Play("downrunPC");
        }


        else if (Input.GetKey(KeyCode.A) && GetComponent<Player>().GetRage() == true)
        {
            anim.Play("leftrunRagePC");
            facingLeft = true;
            facingRight = false;
        }
        else if (Input.GetKey(KeyCode.D) && GetComponent<Player>().GetRage() == true)
        {
            anim.Play("rightrunRagePC");
            facingLeft = false;
            facingRight = true;
        }
        else if (Input.GetKey(KeyCode.W) && GetComponent<Player>().GetRage() == true)
        {
            anim.Play("uprunRagePC");
        }
        else if (Input.GetKey(KeyCode.S) && GetComponent<Player>().GetRage() == true)
        {
            anim.Play("downrunRagePC");
        }
        else if (GetComponent<Player>().GetRage() == true)
        {
            anim.Play("idleRagePC");
        }
        else
        {
            anim.Play("idlePC");
        }





        if (Input.GetKeyDown(KeyCode.A))
        {
            sprites.sprite = directionSprites[3];
            
        }
    }
}












