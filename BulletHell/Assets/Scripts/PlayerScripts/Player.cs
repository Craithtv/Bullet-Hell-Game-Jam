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
    int currRageCounter;
    int maxRageCounter;
    float rageTimer;

    public GameObject [] healthBar;
    public GameObject[] rageBar;

    public AudioSource healthPickUp;
    
    public AudioSource rageStart;
    




    // Start is called before the first frame update
    void Start()
    {
        youDiedScreen.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        hp = startHp;

        currRageCounter = 0;
        maxRageCounter = 4;
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

        if(currRageCounter >= maxRageCounter && Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < maxRageCounter+1; i++){
                rageBar[i].SetActive(false);
            }

            currRageCounter = 0;
            rageTimer = 8f;
            rageStart.Play();
            rageActive = true;
        }

        if(rageActive == true)
        {
            if(rageTimer > 0)
            {

                rageTimer -= Time.deltaTime;

                for (int i = maxRageCounter+1; i < rageBar.Length; i++)
                {
                    if ((int)(maxRageCounter+1 + (maxRageCounter - rageTimer/2)) == i)
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
                rageActive = false;
            }



        }
        else
        {
            
            //For Full rage bar sprite
            //maxRageCounter+1 to make sure max rage is still drawn since there is x+1 number of bar sprites for filling (due to empty bar)
            for (int i = 0; i < maxRageCounter+1; i++)
            {
                if (i != currRageCounter)
                {
                    rageBar[i].SetActive(false);
                }
                else
                {
                    rageBar[i].SetActive(true);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && bulletTimer <=0)
        {
            hp -= 1;

            if (rageActive == false && currRageCounter < maxRageCounter)
                currRageCounter += 1;


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
            healthPickUp.Play();
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
