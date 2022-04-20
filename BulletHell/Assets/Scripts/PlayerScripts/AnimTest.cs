using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    public SpriteRenderer sprites;
    public Sprite [] directionSprites;
    public Animator anim;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
   

        if (Input.GetKey(KeyCode.A) && GetComponent<Player>().GetRage() == false)
        {
            anim.Play("leftrunPC");
        }
        else if (Input.GetKey(KeyCode.D) && GetComponent<Player>().GetRage() == false)
        {
            anim.Play("rightrunPC");
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
        }
        else if (Input.GetKey(KeyCode.D) && GetComponent<Player>().GetRage() == true)
        {
            anim.Play("rightrunRagePC");
        }
        else if (Input.GetKey(KeyCode.W) && GetComponent<Player>().GetRage() == true)
        {
            anim.Play("uprunRagePC");
        }
        else if (Input.GetKey(KeyCode.S) && GetComponent<Player>().GetRage() == true)
        {
            anim.Play("downrunRagePC");
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












