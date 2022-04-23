using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemystartHp;
    public int enemyHp;
    public GameObject healthPickUp;
    const float dropChance = 1f / 2f;
    Bullet bulletScript;

    public Animator anim;
    public GameObject door;
    private Door doorScript;

    private BulletSpawner bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemystartHp;
        anim = gameObject.GetComponent<Animator>();
        bulletSpawner = GetComponent<BulletSpawner>();

        doorScript = door.GetComponent<Door>();

    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHp <= 0 && (Random.Range(0f , 1f) <= dropChance))
        {

            Instantiate(healthPickUp, transform.position, Quaternion.identity);

            doorScript.enemiesLeft--;

            Destroy(gameObject);
        }
        else if(enemyHp <= 0)
        {
            doorScript.enemiesLeft--;
            Destroy(gameObject);
        }


        /*//Bottom Left of player
        if(transform.position.x < bulletSpawner.GetTargetPos().x && transform.position.y < bulletSpawner.GetTargetPos().y)
        {
            anim.Play("enemyRunLeft");
        }

        //Bottom Right of player
        else if (transform.position.x > bulletSpawner.GetTargetPos().x && transform.position.y < bulletSpawner.GetTargetPos().y)
        {
            anim.Play("enemyRunDown");
        }

        //Top Left of player
        else if (transform.position.x < bulletSpawner.GetTargetPos().x && transform.position.y > bulletSpawner.GetTargetPos().y)
        {
            anim.Play("enemyRunUp");
        }

        //Last case; Top Right of player
        else
        {
            anim.Play("enemyRunRight");
        }*/

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
           
            bulletScript = collision.GetComponent<Bullet>();

            enemyHp -= bulletScript.playerBulletDamage;
            anim.CrossFadeInFixedTime("turretDamage", 0);
            anim.CrossFadeInFixedTime("enemyDamage", 0);
            Debug.Log("EnemyHit");

            if(!bulletScript.GetLaserBool())
                Destroy(collision.gameObject);
            
        }
    }


}
