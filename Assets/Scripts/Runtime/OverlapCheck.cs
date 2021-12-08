using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCheck : MonoBehaviour
{

    Collider2D col2D;
    Collider2D[] result;
    public bool FluidCollision = false;
    Rigidbody2D rb;
    public float thrust = 1.0f;
    void Awake()
    {
        col2D = GetComponent<Collider2D>();
        result = new Collider2D[10];
    }

    void OnEnable()
    {
        OverlapCount();
    }

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (FluidCollision == true)
        {
            
        }
    }

    void OverlapCount()
    {
        int count = col2D.OverlapCollider(new ContactFilter2D(), result);
        Debug.Log("Overlap=" + count);
        foreach (var r in result)
        {
            if (r != null) Debug.Log(r.name);
            if (r.name == "LiquidParticle(Clone)")
            {
                Debug.Log("ok");
                FluidCollision = true;
                InvokeRepeating("FloatForce", 1, 1);
               
            }


        }
    }
    void FloatForce()
    {
        rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
    }
}