using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int enemystartHp;
    public int enemyHp;
   
    Bullet bulletScript;

    public Animator anim;


    
    



    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemystartHp;
        anim = gameObject.GetComponent<Animator>();
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHp <= 0)
        { 
            Destroy(gameObject);
        }

       

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
