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
            Debug.Log("Yaik!");
            BottomWarning = true;
            yield return new WaitForSeconds(3.0f);
            Debug.Log("Yaik!");
            BottomWarning = false;
            yield return new WaitForSeconds(3.0f);
            animator.SetBool("BottomLidOpening", true);
            yield return new WaitForSeconds(5.0f);
            animator.SetBool("BottomLidOpening", false);
            BottomWarning = true;
            yield return new WaitForSeconds(3.0f);
            BottomWarning = false;
            animator.SetBool("BottomLidClosing", true);
            bottomLightAnimation.BottomLightWarningEnd = false;
         

        }
    }
    public void LeftLidAnimationEnd()
    {
        BottomEnd = true;
        animator.SetInteger("LidNumber", lidOpenOperation.LidNumber);
        animator.SetBool("BottomLidClosing", false);
       

    }

}