using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pre_LidOpenOperation : MonoBehaviour
{

    public int LidNumber = 1;
    public bool Endsignal=false;
    public Animator LeftLidJoint;
    public Animator RightLidJoint;
    public Animator BottomLidJoint;
    public Animator reactor_bottom_light_red;
    public Animator TopLidJoint;
    public Animator reactor_top_light_red;
    bool LeftEnd = false;
    bool RightEnd = false;
    bool BottomEnd = false;
    bool TopEnd = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if(Endsignal == true)
        {
            LidNumber = 0;
            Endsignal = false;
            LidNumber = Random.Range(1, 5);
        }

        if(LidNumber == 1)
        {
            LeftLidJoint.SetInteger("LidNumber", LidNumber);

            LeftLidJoint.SetBool("LeftLidOpenWarning", true);

            LeftLidJoint.SetBool("LeftLidOpenWarning", false);
            LeftLidJoint.SetBool("LeftLidOpening", true);

            LeftLidJoint.SetBool("LeftLidOpening", false);
            LeftLidJoint.SetBool("LeftLidCloseWarning", true);

            LeftLidJoint.SetBool("LeftLidCloseWarning", false);
            LeftLidJoint.SetBool("LeftLidClosing", true);
            Endsignal = true;
            LeftEnd = true;

        }

        if (LidNumber == 2)
        {
            RightLidJoint.SetInteger("LidNumber",LidNumber);

            RightLidJoint.SetBool("RightLidOpenWarning", true);

            RightLidJoint.SetBool("RightLidOpenWarning", false);
            RightLidJoint.SetBool("RightLidOpening", true);

            RightLidJoint.SetBool("RightLidOpening", false);

            RightLidJoint.SetBool("RightLidCloseWarning", false);
            RightLidJoint.SetBool("RightLidClosing", true);
            Endsignal = true;
            RightEnd = true;

        }

        if (LidNumber == 3)
        {
            BottomLidJoint.SetInteger("LidNumber", LidNumber);
            reactor_bottom_light_red.SetInteger("LidNumber", LidNumber);

            reactor_bottom_light_red.SetBool("BottomOpenLidWarning", true);

            reactor_bottom_light_red.SetBool("BottomOpenLidWarning", false);
            BottomLidJoint.SetBool("BottomLidOpening", true);

            BottomLidJoint.SetBool("BottomLidOpening", false);
            reactor_bottom_light_red.SetBool("BottomCloseLidWarning", true);

            reactor_bottom_light_red.SetBool("BottomCloseLidWarning", false);
            BottomLidJoint.SetBool("BottomLidClosing", true);
            Endsignal = true;
            BottomEnd = true;

        }

        if (LidNumber == 4)
        {
            TopLidJoint.SetInteger("LidNumber",LidNumber);
            reactor_top_light_red.SetInteger("LidNumber",LidNumber);
 
            reactor_top_light_red.SetBool("TopLidOpenWarning", true);

            reactor_top_light_red.SetBool("TopLidOpenWarning", false);
            TopLidJoint.SetBool("TopLidOpening", true);

            TopLidJoint.SetBool("TopLidOpening", false);
            reactor_top_light_red.SetBool("TopLidCloseWarning", true);
            
            reactor_top_light_red.SetBool("TopLidCloseWarning", false);
            TopLidJoint.SetBool("TopLidClosing", true);
            Endsignal = true;
            TopEnd = true;

        }

    }
}
