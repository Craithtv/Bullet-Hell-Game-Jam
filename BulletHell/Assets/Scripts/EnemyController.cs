using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemystartHp;
    int enemyHp;
    public GameObject healthPickUp;
    const float dropChance = 1f / 5f;


    // Start is called before the first frame update
    void Start()
    {
        enemyHp = enemystartHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHp <= 0 && (Random.Range(0f , 1f) <= dropChance))
        {

            Instantiate(healthPickUp, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            enemyHp -= 1;
            Debug.Log("EnemyHit");
            
        }
    }


}
