using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int startHp = 6;
    int hp;
    public float bulletCooldown;
    float bulletTimer;
    public Canvas youDiedScreen;

    bool rageActive;
    int rageCounter;
    float rageTimer;

    public GameObject [] healthBar;
    public GameObject[] rageBar;

    

    // Start is called before the first frame update
    void Start()
    {
        youDiedScreen.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        hp = startHp;

        rageCounter = 0;
        rageActive = false;

        foreach(GameObject obj in healthBar)
        {
            obj.SetActive(false);
        }
        healthBar[0].SetActive(true);

        foreach(GameObject obj in rageBar)
        {
            obj.SetActive(false);
        }
        rageBar[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer -= Time.deltaTime;


        if(rageCounter >= 4 && Input.GetKeyDown(KeyCode.E))
        {
            rageCounter = 0;
            rageTimer = 8f;
            rageActive = true;
        }

        if(rageActive == true)
        {
            if(rageTimer > 0)
            {

                rageTimer -= Time.deltaTime;

                for (int i = rageBar.Length - 1; i >= 0; i--)
                {
                    if ((int)rageTimer/2 >= i-1)
                    {
                        rageBar[i].SetActive(true);
                    }
                    

                    else
                    {
                        rageBar[i].SetActive(false);
                    }
                }

              
            }
            else
            {
                //For if using individual sprites
                /*for(int i = 0; i < rageBar.Length; i++)
                {
                    rageBar[i].SetActive(false);
                }*/


                rageActive = false;
            }



        }
        else
        {
            
            //For Full rage bar sprite
            for (int i = 0; i < rageBar.Length; i++)
            {
                if (i != rageCounter)
                {
                    rageBar[i].SetActive(false);
                }
                else
                {
                    rageBar[i].SetActive(true);
                }
            }


            //For Individual rage bar sprites
            /*for (int i = 0; i < rageBar.Length; i++)
            {
                if(i == rageCounter)
                {
                    rageBar[i].SetActive(true);
                }
            }*/
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && bulletTimer <=0)
        {
            hp -= 1;

            if (rageActive == false && rageCounter < 4)
                rageCounter += 1;


            Debug.Log("Hit");
            bulletTimer = bulletCooldown;
            Destroy(collision.gameObject);


        }

        if (collision.tag == "UnlockedDoor")
        {
           
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Health" && hp <=5)
        {
            hp++;
            Destroy(collision.gameObject);
        }

        if (hp == 6)
        {  
            healthBar[0].SetActive(true);
            healthBar[1].SetActive(false);
            healthBar[2].SetActive(false);
            healthBar[3].SetActive(false);
            healthBar[4].SetActive(false);
            healthBar[5].SetActive(false);
            healthBar[6].SetActive(false);
        }
        else if (hp == 5)
        {  
            healthBar[0].SetActive(false);
            healthBar[1].SetActive(true);
            healthBar[2].SetActive(false);
            healthBar[3].SetActive(false);
            healthBar[4].SetActive(false);
            healthBar[5].SetActive(false);
            healthBar[6].SetActive(false);
        }
        else if (hp == 4)
        {  
            healthBar[0].SetActive(false);
            healthBar[1].SetActive(false);
            healthBar[2].SetActive(true);
            healthBar[3].SetActive(false);
            healthBar[4].SetActive(false);
            healthBar[5].SetActive(false);
            healthBar[6].SetActive(false);
        }
        else if (hp == 3)
        {  
            healthBar[0].SetActive(false);
            healthBar[1].SetActive(false);
            healthBar[2].SetActive(false);
            healthBar[3].SetActive(true);
            healthBar[4].SetActive(false);
            healthBar[5].SetActive(false);
            healthBar[6].SetActive(false);
        }
        else if (hp == 2)
        {  
            healthBar[0].SetActive(false);
            healthBar[1].SetActive(false);
            healthBar[2].SetActive(false);
            healthBar[3].SetActive(false);
            healthBar[4].SetActive(true);
            healthBar[5].SetActive(false);
            healthBar[6].SetActive(false);
        }
        else if (hp == 1)
        {  
            healthBar[0].SetActive(false);
            healthBar[1].SetActive(false);
            healthBar[2].SetActive(false);
            healthBar[3].SetActive(false);
            healthBar[4].SetActive(false);
            healthBar[5].SetActive(true);
            healthBar[6].SetActive(false);
        }
        else if (hp == 0)
        {
            youDiedScreen.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;

            healthBar[0].SetActive(false);
            healthBar[1].SetActive(false);
            healthBar[2].SetActive(false);
            healthBar[3].SetActive(false);
            healthBar[4].SetActive(false);
            healthBar[5].SetActive(false);
            healthBar[6].SetActive(true);
        }
        
    }

    public int GetPlayerHp()
    {
        return hp;
    }

    public bool GetRage()
    {
        return rageActive;
    }
}
