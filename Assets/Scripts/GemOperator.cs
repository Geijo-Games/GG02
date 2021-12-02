using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemOperator : MonoBehaviour
{
    public GemCollider gemCollider;
    public int GemCounter;
    public bool GemDestroyFlag;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    void DoubledGemSpown()
    {
        if (GemCounter == 2)
        {
            Instantiate(obj, gemCollider.GemPosition, Quaternion.identity);
            GemDestroyFlag = true;
        }
    }
}
