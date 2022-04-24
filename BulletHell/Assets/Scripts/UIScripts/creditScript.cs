using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditScript : MonoBehaviour
{

    public Canvas creditScreen;



    // Start is called before the first frame update
    void Start()
    {creditScreen.GetComponent<Canvas>().enabled = false;
    }

    public void BackCreditsButton()
        
    {
        creditScreen.GetComponent<Canvas>().enabled = false;
    }


    public void CreditsButton()
    {
        creditScreen.GetComponent<Canvas>().enabled = true;
    }
}
