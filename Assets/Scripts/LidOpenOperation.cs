using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidOpenOperation : MonoBehaviour
{
    //Animator animator;
    public int LidNumber = 1;
    public LeftLidAnimation leftLidAnimation;
    bool isLeftEnd= false;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
       // isLeftEnd = leftLidAnimation.LeftEnd;
    }

    // Update is called once per frame
    private void Update()
    {
        if (leftLidAnimation.LeftEnd == true)
        {
            LidNumber = 2;
            Debug.Log("OK!");
        }
    }
}
