using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLidAnimation : MonoBehaviour
{
    Animator animator;
    public bool RightEnd = false;
    public LidOpenOperation lidOpenOperation;
    
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
        if (lidOpenOperation.LidNumber == 2)
        {
            animator.SetInteger("LidNumber", lidOpenOperation.LidNumber);
            Debug.Log("Yaik!");
            yield return new WaitForSeconds(3.0f);
            Debug.Log("Yaik!");
            animator.SetBool("RightLidOpenWarning", true);
            yield return new WaitForSeconds(3.0f);
            animator.SetBool("RightLidOpenWarning", false);
            animator.SetBool("RightLidOpening", true);
            yield return new WaitForSeconds(5.0f);
            animator.SetBool("RightLidOpening", false);
            animator.SetBool("RightLidCloseWarning", true);
            yield return new WaitForSeconds(3.0f);
            animator.SetBool("RightLidCloseWarning", false);
            animator.SetBool("RightLidClosing", true);
        }
    }
    public void RightLidAnimationEnd()
    {
        RightEnd = true;
        animator.SetInteger("LidNumber", lidOpenOperation.LidNumber);
        animator.SetBool("RightLidClosing", false);
        lidOpenOperation.Endsignal = true;
    }

}
