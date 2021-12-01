using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollider : MonoBehaviour
{
    public Vector3 GemPosition;
    public GemOperator gemOperator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "gem")
        {
            GemPosition = this.gameObject.transform.position;
            Destroy(this.gameObject);
            Debug.Log(GemPosition);
            gemOperator.GemCounter += 1;

        }

    }
}

 