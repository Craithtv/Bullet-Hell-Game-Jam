using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTest : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashThrust = 20f;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))

        {rb.AddForce(transform.up * dashThrust);}
    }
}
