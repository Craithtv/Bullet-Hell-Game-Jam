using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipSpriteTest : MonoBehaviour
{
    //!Not an important script, just testing to see if the sprite actuall flips cause current placeholder is identical on both sides
    
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<SpriteRenderer>().flipX == true)
        {
            gameObject.transform.position = player.transform.position - player.GetComponent<BoxCollider2D>().bounds.extents;
        }

        else
        {
            gameObject.transform.position = player.transform.position + player.GetComponent<BoxCollider2D>().bounds.extents;
        }
    }
}
