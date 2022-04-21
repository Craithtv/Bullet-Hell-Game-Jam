using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;
    public float rotation;
    public int playerBulletDamage;

    public bool isLaser;
    SpriteRenderer bulletRender;

    public LayerMask wallLayers;


    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        bulletRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);

        if (isLaser)
        {
            bulletRender.color -= new Color(0f, 0f, 0f, Time.deltaTime);
            if(bulletRender.color.a <= 0f)
            {
                Destroy(gameObject);
            }
        }

        DestroyBullet();
    }

    void DestroyBullet()
    {
        if(Physics2D.OverlapArea(gameObject.GetComponent<BoxCollider2D>().bounds.max, gameObject.GetComponent<BoxCollider2D>().bounds.min, wallLayers)){
            Destroy(gameObject);
        }
    }

    public bool GetLaserBool()
    {
        return isLaser;
    }
}
