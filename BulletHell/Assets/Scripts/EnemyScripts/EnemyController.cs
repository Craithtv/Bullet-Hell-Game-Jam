using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemystartHp;
    public int enemyHp;
    public GameObject healthPickUp;
    const float dropChance = 1f / 2f;
    public Bullet bulletScript;


    public GameObject door;
    private Door doorScript;



    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemystartHp;

        
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
