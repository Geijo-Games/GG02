using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollision : MonoBehaviour
{
    public float thrust = 1.0f;
   //  Rigidbody2D rb;
    Transform myTransform;
    bool collisionflag;
    // Start is called before the first frame update
    void Start()
    {
       // rb = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (collisionflag == true)
        {
            myTransform = this.gameObject.transform;
            Vector3 pos = myTransform.position;
            pos.y += 0.005f;
            myTransform.position = pos;  // ç¿ïWÇê›íË
        }
    }
    void FixedUpdate()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
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
