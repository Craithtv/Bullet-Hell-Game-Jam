using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemystartHp;
    public int enemyHp;
    public GameObject healthPickUp;
    const float dropChance = 1f / 5f;
    public Bullet bulletScript;


    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemystartHp;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enemyHp <= 0 && (Random.Range(0f , 1f) <= dropChance))
        {

            Instantiate(healthPickUp, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {



            bulletScript = GameObject.Find("PlayerBullet(Clone)").GetComponent<Bullet>();

            enemyHp -= bulletScript.playerBulletDamage;
            Debug.Log("EnemyHit");
            Destroy(collision.gameObject);
            
        }
    }


}
