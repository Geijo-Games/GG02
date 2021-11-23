using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLidAnimation : MonoBehaviour
{
    Animator animator;
    public LidOpenOperation lidOpenOperation;

    public bool TopEnd = false;
    public bool TopWarning = false;
    public Animator reactor_top_light_red;
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
        if (lidOpenOperation.LidNumber == 4)
        {
            animator.SetInteger("LidNumber", lidOpenOperation.LidNumber);
            reactor_top_light_red.SetInteger("LidNumber", lidOpenOperation.LidNumber);
            // yield return new WaitForSeconds(3.0f);
            reactor_top_light_red.SetBool("TopLidOpenWarning", true);
            yield return new WaitForSeconds(3.0f);
            reactor_top_light_red.SetBool("TopLidOpenWarning", false);
            animator.SetBool("TopLidOpening", true);
            yield return new WaitForSeconds(5.0f);
            animator.SetBool("TopLidOpening", false);
            reactor_top_light_red.SetBool("TopLidCloseWarning", true);
            yield return new WaitForSeconds(3.0f);
            reactor_top_light_red.SetBool("TopLidCloseWarning", false);
            animator.SetBool("TopLidClosing", true);



        }
    }
    public void LeftLidAnimationEnd()
    {
       TopEnd = true;
        animator.SetInteger("LidNumber", lidOpenOperation.LidNumber);
        animator.SetBool("TopLidClosing", false);
        lidOpenOperation.Endsignal = true;

    }

}
