using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int enemystartHp;
    public int enemyHp;
   
    Bullet bulletScript;

    public Animator anim;
    public AudioSource mainSong;

    public Canvas Victory;
    



    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemystartHp;
        anim = gameObject.GetComponent<Animator>();
        mainSong.Stop();
        Victory.GetComponent<Canvas>().enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHp <= 0)
        {
            mainSong.Play();
            Victory.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;

            Destroy(gameObject);
        }
        else
            mainSong.Stop();
       

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            
            anim.SetTrigger("isHit");
            bulletScript = collision.GetComponent<Bullet>();

            
            enemyHp -= bulletScript.playerBulletDamage;
            
            Debug.Log("EnemyHit");

            if (!bulletScript.GetLaserBool())
                Destroy(collision.gameObject);
          

        }
    }
   
}
