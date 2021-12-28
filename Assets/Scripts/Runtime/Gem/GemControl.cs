using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemControl : MonoBehaviour
{
    Vector3 prevPos;
    Rigidbody2D rigid;

    bool ShouldGoAway = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 2 && !ShouldGoAway)
        {
            if (LidController.Instance!= null && LidController.Instance.IsLidOpening())
            {
                ShouldGoAway = true;
            }
            if (rigid)
            {
                rigid.isKinematic = true;
                //transform.position = prevPos;
                transform.position = new Vector3(Random.Range(0, 2), Random.Range(0, 2));
                rigid.isKinematic = false;
            }
        }
        prevPos = transform.position;
    }
}
