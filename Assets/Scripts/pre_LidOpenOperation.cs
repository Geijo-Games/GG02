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
            Invoke("LeftLidOpen", 3);
            Invoke("LeftCloseWarningStart", 10);   
            
        }


        if (LidNumber == 2)
        {
            RightLidJoint.SetInteger("LidNumber",LidNumber);
            RightLidJoint.SetBool("RightLidOpenWarning", true);
            Invoke("RightLidOpen", 3);
            Invoke("RightCloseWarningStart", 10);

        }

        if (LidNumber == 3)
        {
            BottomLidJoint.SetInteger("LidNumber", LidNumber);
            reactor_bottom_light_red.SetInteger("LidNumber", LidNumber);
            reactor_bottom_light_red.SetBool("BottomOpenLidWarning", true);
            Invoke("BottomLidOpen", 3);
            Invoke("BottomCloseWarningStart", 10);
        }

        if (LidNumber == 4)
        {
            TopLidJoint.SetInteger("LidNumber",LidNumber);
            reactor_top_light_red.SetInteger("LidNumber",LidNumber);
            reactor_top_light_red.SetBool("TopLidOpenWarning", true);
            Invoke("TopLidOpen", 3);
            Invoke("TopCloseWarningStart", 10);



            reactor_top_light_red.SetBool("TopLidCloseWarning", true);
            
            reactor_top_light_red.SetBool("TopLidCloseWarning", false);
            TopLidJoint.SetBool("TopLidClosing", true);
            


        }

    }
    // left lid
    void LeftLidOpen()
    {
        LeftLidJoint.SetBool("LeftLidOpenWarning", false);
        LeftLidJoint.SetBool("LeftLidOpening", true);
    }
    void LeftCloseWarningStart()
    {
        LeftLidJoint.SetBool("LeftLidOpening", false);
        LeftLidJoint.SetBool("LeftLidCloseWarning", true);
        Endsignal = true;
        Invoke("LeftLidClose", 3);
    }
    void LeftLidClose()
    {
        LeftLidJoint.SetBool("LeftLidCloseWarning", false);
        LeftLidJoint.SetTrigger("LeftLidClosing");
        LeftLidJoint.SetInteger("LidNumber", LidNumber);
    }

    //Right lid
    void RightLidOpen()
    {
        RightLidJoint.SetBool("RightLidOpenWarning", false);
        RightLidJoint.SetBool("RightLidOpening", true);
    }
    public void RightCloseWarningStart()
    {

        RightLidJoint.SetBool("RightLidOpening", false);
        RightLidJoint.SetBool("RightLidCloseWarning",true);
        Endsignal = true;
        Invoke("RightLidClose", 3);
    }
    void RightLidClose()
    {
        RightLidJoint.SetBool("RightLidCloseWarning", false);
        RightLidJoint.SetTrigger("RightLidClosing");
        RightLidJoint.SetInteger("LidNumber", LidNumber);
    }


    //Bottom lid
    void BottomLidOpen()
    {
        reactor_bottom_light_red.SetBool("BottomOpenLidWarning", false);
        BottomLidJoint.SetBool("BottomLidOpening", true);
    }
    public void BottomCloseWarningStart()
    {
        BottomLidJoint.SetBool("BottomLidOpening", false);
        reactor_bottom_light_red.SetBool("BottomCloseLidWarning", true);
        Endsignal = true;
        Invoke("BottomLidClose", 3);

    }
    void BottomLidClose()
    {
        reactor_bottom_light_red.SetBool("BottomCloseLidWarning", false);
        BottomLidJoint.SetTrigger("BottomLidClosing");
        BottomLidJoint.SetInteger("LidNumber", LidNumber);
    }

    //Top lid
    void TopLidOpen()
    {
        reactor_top_light_red.SetBool("TopLidOpenWarning", false);
        TopLidJoint.SetBool("TopLidOpening", true);
    }
    public void TopCloseWarningStart()
    {
        TopLidJoint.SetBool("TopLidOpening", false);
        reactor_top_light_red.SetBool("TopLidCloseWarning", true);
        Endsignal = true;
        Invoke("TopLidClose", 3);
    }
    void TopLidClose()
    {
        reactor_top_light_red.SetBool("TopLidCloseWarning", false);
        TopLidJoint.SetTrigger("TopLidClosing");
        TopLidJoint.SetInteger("LidNumber", LidNumber);
    }
}
