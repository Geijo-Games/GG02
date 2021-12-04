using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BottomLightAnimation : MonoBehaviour
{
    Animator animator;
    public BottomLidAnimation bottomLidAnimation;
    public bool BottomLightWarningEnd = false;
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
        if (bottomLidAnimation.BottomWarning == true )
        {
            animator.SetBool("BottomLidWarning", true);
            yield return new WaitForSeconds(3.0f);
            animator.SetBool("BottomLidWarning", false);
            
        }


    }

}
