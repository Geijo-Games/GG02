using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLidAnimation : MonoBehaviour
{
    Animator animator;
    IEnumerator coroutine;
    public LidOpenOperation lidOpenOperation;
  
    public bool LeftEnd = false;
    // Start is called before the first frame update
    void Start()
    {


        
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IEnumerator coroutine = LidAnimation();
        StartCoroutine(coroutine);
        if(lidOpenOperation.Endsignal == true)
        {
            StopCoroutine(coroutine);
            coroutine = LidAnimation();
            Debug.Log("wwww");
            StartCoroutine(coroutine);
        }
    }

    IEnumerator LidAnimation()
    {
   
            if (lidOpenOperation.LidNumber == 1)
        {
 
                animator.SetInteger("LidNumber", lidOpenOperation.LidNumber);
            yield return new WaitForSeconds(3.0f);
            animator.SetBool("LeftLidOpenWarning", true);
            yield return new WaitForSeconds(3.0f);
            animator.SetBool("LeftLidOpenWarning", false);
            animator.SetBool("LeftLidOpening", true);
            yield return new WaitForSeconds(5.0f);
            animator.SetBool("LeftLidOpening", false);
            animator.SetBool("LeftLidCloseWarning", true);
            yield return new WaitForSeconds(3.0f);
            animator.SetBool("LeftLidCloseWarning", false);
            animator.SetBool("LeftLidClosing", true);



        }


    }
    public void LeftLidAnimationEnd()
    {
        LeftEnd = true;
        animator.SetInteger("LidNumber", lidOpenOperation.LidNumber);
        animator.SetBool("LeftLidClosing", false);
        lidOpenOperation.Endsignal = true;
    }
}


