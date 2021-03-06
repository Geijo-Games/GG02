using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLidAnimation : MonoBehaviour
{
    Animator animator;
    public LidOpenOperation lidOpenOperation;
    public BottomLightAnimation bottomLightAnimation;
    public bool BottomEnd = false;
    public bool BottomWarning = false;
    public Animator reactor_bottom_light_red;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("LidAnimation");
    }

    IEnumerator LidAnimation()
    {
        if (lidOpenOperation.LidNumber == 3)
        {
            animator.SetInteger("LidNumber", lidOpenOperation.LidNumber);
            reactor_bottom_light_red.SetInteger("LidNumber", lidOpenOperation.LidNumber);
            // yield return new WaitForSeconds(3.0f);
            reactor_bottom_light_red.SetBool("BottomOpenLidWarning",true);
            yield return new WaitForSeconds(3.0f);
            reactor_bottom_light_red.SetBool("BottomOpenLidWarning", false);
            animator.SetBool("BottomLidOpening", true);
            yield return new WaitForSeconds(5.0f);
            animator.SetBool("BottomLidOpening", false);
            reactor_bottom_light_red.SetBool("BottomCloseLidWarning", true);
            yield return new WaitForSeconds(3.0f);
            reactor_bottom_light_red.SetBool("BottomCloseLidWarning", false);
            animator.SetBool("BottomLidClosing", true);

         

        }
    }
    public void LeftLidAnimationEnd()
    {
        BottomEnd = true;
        animator.SetInteger("LidNumber", lidOpenOperation.LidNumber);
        animator.SetBool("BottomLidClosing", false);
        lidOpenOperation.Endsignal = true;

    }

}