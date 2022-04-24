using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podTutorial : MonoBehaviour
{
    
    public GameObject[] tutorialOne;
    public GameObject spaceEscape;


    public SpriteRenderer spriteRenderer;
    public Sprite brokenPodSprite;
    public Canvas advancedButtons;
    public Canvas enemyDialog1;
    public Canvas pcDialog1;
    public Canvas basicButtons;
    public GameObject child;

    private bool isFree = false;
    private bool hasTalked = false;
   


    // Start is called before the first frame update
    void Start()
    {
        enemyDialog1.GetComponent<Canvas>().enabled = false;
        pcDialog1.GetComponent<Canvas>().enabled = false;
        basicButtons.GetComponent<Canvas>().enabled = false;
        advancedButtons.GetComponent<Canvas>().enabled = false;


        for (int i = 0; i < tutorialOne.Length; i++)
        {
            tutorialOne[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && isFree == false)
        {


            for (int i = 0; i < tutorialOne.Length; i++) tutorialOne[i].SetActive(true);

            Destroy(spaceEscape);
            spriteRenderer.sprite = brokenPodSprite;
            GameObject.Destroy(child.gameObject);
            isFree = true;
            enemyDialog1.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isFree == true)

        {

            enemyDialog1.GetComponent<Canvas>().enabled = false;         
            Time.timeScale = 1;
            
            if(hasTalked == false)
            {
                pcDialog1.GetComponent<Canvas>().enabled = true;
                hasTalked = true;
            }
            else
            {
                return;
            }
        }



       








    }

}
