using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    public SpriteRenderer sprites;
    public Sprite [] directionSprites;
    public Animator anim;
    public bool isRaging = false;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
   

        if (Input.GetKey(KeyCode.A))
        {
            anim.Play("leftrunPC");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.Play("rightrunPC");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            anim.Play("uprunPC");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.Play("downrunPC");
        }





        if (Input.GetKeyDown(KeyCode.A))
        {
            sprites.sprite = directionSprites[3];
            
        }
    }
}












