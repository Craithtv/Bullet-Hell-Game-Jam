using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int enemiesLeft;
    public GameObject [] enemies;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemies.Length; i++) 
        {
        enemies[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesLeft <= 0)
        {
         for(int i = 0; i < enemies.Length; i++)enemies[i].SetActive(true);
        
            
        Destroy(this);
        }
    }
}
