using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTest : MonoBehaviour
{
    private float meleeTimeBtwAttack;
    private float rangedTimeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;
    Collider2D[] enemiesToDamage;

    public AimAtMouse aimAtMouse;
    public GameObject playerBulletPrefab;
    public GameObject playerLaserPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Rage inactive, use melee
        if(GetComponent<Player>().GetRage() == false)
        {
            if (meleeTimeBtwAttack <= 0)
            {//then you can attack
                if (Input.GetMouseButton(0))
                {
                    meleeTimeBtwAttack = startTimeBtwAttack;
                    enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<EnemyController>().enemyHp -= damage;
                    }

                }

            }
            else
            {
                meleeTimeBtwAttack -= Time.deltaTime;
            }

            if (rangedTimeBtwAttack <= 0)
            {
                if (Input.GetMouseButton(1))
                {
                    rangedTimeBtwAttack = startTimeBtwAttack;
                    GameObject playerBullet = Instantiate(playerBulletPrefab, transform.position, Quaternion.Euler(Vector3.zero));
                    playerBullet.GetComponent<Bullet>().velocity = -attackPos.GetComponent<AimAtMouse>().GetDirection();
                }
            }
            else
            {
                rangedTimeBtwAttack -= Time.deltaTime;
            }
        }

        //Rage active, use range
        else
        {
            
            if (rangedTimeBtwAttack <= 0)
            {
                if (Input.GetMouseButton(1))
                {
                    RaycastHit2D rayHit = Physics2D.Raycast(transform.position, aimAtMouse.GetDirection(), Mathf.Infinity, GetComponent<PlayerMovement>().GetWallLayers());

                    rangedTimeBtwAttack = startTimeBtwAttack;
                    GameObject playerBullet = Instantiate(playerLaserPrefab, (transform.position + aimAtMouse.GetDirection() * rayHit.distance/2), Quaternion.Euler(Vector3.zero));

                    playerBullet.GetComponent<Bullet>().rotation =  90f + aimAtMouse.GetZRotation();

                    playerBullet.transform.localScale = new Vector3(playerBullet.transform.localScale.x, rayHit.distance/2);
                    //playerBullet.transform.localScale = new Vector3(rayHit.distance, playerBullet.transform.localScale.y);
                }
            }

            else
            {
                rangedTimeBtwAttack -= Time.deltaTime;
            }

            
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public float GetAttackRange()
    {
        return attackRange;
    }


    
}
