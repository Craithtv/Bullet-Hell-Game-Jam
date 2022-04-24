using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podTutorial : MonoBehaviour
{
    
    public GameObject[] tutorialOne;



    // Start is called before the first frame update
    void Start()
    {




        for (int i = 0; i < tutorialOne.Length; i++)
        {
            tutorialOne[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {


            for (int i = 0; i < tutorialOne.Length; i++) tutorialOne[i].SetActive(true);


            Destroy(this.gameObject);
        }


    }


}
