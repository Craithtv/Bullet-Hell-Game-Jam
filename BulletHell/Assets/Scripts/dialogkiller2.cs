using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogkiller2 : MonoBehaviour
{

    public Canvas advancedButtons;
    public Canvas basicButtons;




    void OnTriggerEnter2D(Collider2D col)
    {
        advancedButtons.GetComponent<Canvas>().enabled = true;

        basicButtons.GetComponent<Canvas>().enabled = false;
    }
}
