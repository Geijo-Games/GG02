using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollider2 : MonoBehaviour
{
    public Vector3 GemPosition;
   
    bool GemDestroyFlag;
    public GameObject obj;
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
            GemDestroyFlag = true;
           // Debug.Log(GemPosition);
            Instantiate(obj, GemPosition, Quaternion.identity);
            Destroy(this.gameObject);
            GemDestroyFlag = true;
        }

    }

    void GemDestroy()
    {
        if(GemDestroyFlag == true)
        {
           

        }

        
    }
}

 