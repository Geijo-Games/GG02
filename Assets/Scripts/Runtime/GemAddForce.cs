using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemAddForce : MonoBehaviour
{
    float thrust = 20.0f;
    Rigidbody2D rb2D;
    Vector2 GemShootDirection;
    // Start is called before the first frame update
    void Start()
    {
        GemShootDirection = new Vector2(-1, -1);
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.up, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
