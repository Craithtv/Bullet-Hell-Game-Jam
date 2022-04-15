using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Animator animator;

     bool facingRight = false;
     bool facingLeft = false;
     bool facingDown = false;
     bool facingUp = false;
     
    private Vector3 previousX;
    

    void Start()
    {
       animator = GetComponent<Animator>();

    }




    void Update()
    {
        var delta = transform.position = transform.position - previousX;

        if(delta.x < 0)
        {
            facingRight = true;
            bool facingLeft = false;
            bool facingDown = false;
            bool facingUp = false;
            
        }
        else
        {
            facingLeft = true;
        }
    
        



    }

    

}
