using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLidAnimation : MonoBehaviour
{
    Animator animator;

    public LidOpenOperation lidOpenOperation;
    int LidNum;
    // Start is called before the first frame update
    void Start()
    {
        LidNum = lidOpenOperation.LidNumber;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("LidAnimation");
    }

    IEnumerator LidAnimation()
    {
        if (LidNum == 2)
        {
            animator.SetInteger("LidNumber", 1);
            Debug.Log("Yaik!");
            yield return new WaitForSeconds(3.0f);
            Debug.Log("Yaik!");
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
        LidNum = 3;
        animator.SetInteger("LidNumber", 3);
        animator.SetBool("LeftLidClosing", false);
    }

}
