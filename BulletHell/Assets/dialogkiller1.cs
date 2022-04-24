using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogkiller1 : MonoBehaviour
{
    public Canvas pcDiag1;
    public Canvas basicButtons;
    
    
   
    
    void OnTriggerEnter2D(Collider2D col)
    {
        pcDiag1.GetComponent<Canvas>().enabled = false;
        basicButtons.GetComponent<Canvas>().enabled = true;
    }
}
