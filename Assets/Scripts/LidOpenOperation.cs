using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidOpenOperation : MonoBehaviour
{
    //Animator animator;
    public int LidNumber = 1;
    public LeftLidAnimation leftLidAnimation;
    public RightLidAnimation rightLidAnimation;
    public BottomLidAnimation bottomLidAnimation;
    public TopLidAnimation topLidAnimation;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
       // isLeftEnd = leftLidAnimation.LeftEnd;
    }

    // Update is called once per frame
    private void Update()
    {
        if (topLidAnimation.TopEnd == true)
        {
            LidNumber = 1;
            Debug.Log("OK!,return");
            topLidAnimation.TopEnd = false;
        }
        if (bottomLidAnimation.BottomEnd == true)
        {
            LidNumber = 4;
            Debug.Log("OK!,4");
            bottomLidAnimation.BottomEnd = false;
        }
        if (rightLidAnimation.RightEnd == true)
        {
            LidNumber = 3;
            Debug.Log("OK!,3");
            rightLidAnimation.RightEnd = false;
        }

        if (leftLidAnimation.LeftEnd == true)
        {
            LidNumber = 2;
            Debug.Log("OK!,2");
            leftLidAnimation.LeftEnd = false;
        }
    }
}
