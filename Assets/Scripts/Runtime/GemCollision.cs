using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollision : MonoBehaviour
{
    public float thrust = 1.0f;
     Rigidbody2D rb;
    bool collisionflag;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionflag == true)
        {
            rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            Debug.Log("ok");
        }
    }
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fluid")
        {
            collisionflag = true;
        }
        else
        {
            collisionflag = false;
        }
    }
}
