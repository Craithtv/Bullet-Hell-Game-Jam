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
        if (Input.GetKey(KeyCode.S))
        {
            sprites.sprite = directionSprites[0];
        }  
        else if (Input.GetKey(KeyCode.D))
        {
            sprites.sprite = directionSprites[1];
        }
        else if (Input.GetKey(KeyCode.W))
        {
            sprites.sprite = directionSprites[2];
        }
        else if (Input.GetKey(KeyCode.A))
        {
            sprites.sprite = directionSprites[3];
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.Play("leftrunPC");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.Play("rightrunPC");
        }

    }
}
